using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Domain.Models;
using SimpleWebApi.Service.Interface;
using SimpleWebApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Service.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICountryRepository _countryRepository;

        public ContactService(IContactRepository contactRepository, ICompanyRepository companyRepository, ICountryRepository countryRepository)
        {
            _contactRepository = contactRepository;
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
        }

        public int Create(AddContactDTO addContact)
        {
            if (addContact == null) throw new ArgumentNullException("Contact is Null");

            Contact contact = new Contact()
            {
                ContactName = addContact.ContactName,
                CompanyId = addContact.CompanyId,
                CountryId = addContact.CountryId,
            };
            int addedContact = _contactRepository.Create(contact);

            Company? company = _companyRepository.GetById(addContact.CompanyId);

            if (company == null)
                throw new Exception("Company cannot be null");

            Country? country = _countryRepository.GetById(addContact.CountryId);

            if (country == null)
                throw new Exception("Country cannot be null");

            company.Contacts.Add(contact);
            country.Contacts.Add(contact);

            _companyRepository.Update(company);
            _countryRepository.Update(country);

            return addedContact;

        }

        public void Delete(int? contactId)
        {
            if (contactId == null) throw new ArgumentNullException("Contact is Null");

            var contact = _contactRepository.GetById(contactId);
            if (contact == null) 
                throw new Exception("Contact cannot be null");

            _contactRepository.Delete(contact);
        }

        public ICollection<Contact> FilterContact(int? countryId, int? companyId)
        {
            if (countryId == null && companyId == null)
            {
                return _contactRepository.GetAll();
            }

            if (countryId != null && companyId != null)
            {
                return _contactRepository.FilterContactByCountryIdAndCompanyId(countryId, companyId);
            }

            if (companyId != null && countryId == null)
            {
                return _contactRepository.FilterContactByCompanyId(companyId);
            }

            if (countryId != null && companyId == null)
            {
                return _contactRepository.FilterContactByCountryId(countryId);
            }

            return new List<Contact>();
        }

        public ICollection<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetById(int? contactId)
        {
            if (contactId == null) throw new ArgumentNullException("Contact is Null");

            var contact = _contactRepository.GetById(contactId);

            if (contact == null) throw new ArgumentNullException("Contact is Null");

            return contact;
        }

        public ICollection<Contact> GetContactsWithCompanyAndCountry()
        {
            return _contactRepository.GetContactsWithCompanyAndCountry();
        }

        public Contact Update(int? id, UpdateContactDTO updateContact)
        {
            var contactToUpdate = _contactRepository.GetById(id);

            if (contactToUpdate == null)
                throw new Exception("Contact not found");

            if (updateContact == null)
                throw new Exception("Contact is Null");

            contactToUpdate.ContactName = updateContact.ContactName;

            if(contactToUpdate.CompanyId != updateContact.CompanyId)
            {
                var currCompany = _companyRepository.GetById(contactToUpdate.CompanyId);

                if (currCompany != null)
                    currCompany.Contacts.Remove(contactToUpdate);

                var newCompany = _companyRepository.GetById(updateContact.CompanyId);

                if (newCompany != null)
                    newCompany.Contacts.Add(contactToUpdate);

                _companyRepository.Update(currCompany);
                _companyRepository.Update(newCompany);
                contactToUpdate.CompanyId = updateContact.CompanyId;
            }

            if(contactToUpdate.CountryId != updateContact.CountryId)
            {
                var currCountry = _countryRepository.GetById(contactToUpdate.CountryId);

                if (currCountry != null)
                    currCountry.Contacts.Remove(contactToUpdate);

                var newCountry = _countryRepository.GetById(updateContact.CountryId);

                if (newCountry != null)
                    newCountry.Contacts.Add(contactToUpdate);

                _countryRepository.Update(currCountry);
                _countryRepository.Update(newCountry);
                contactToUpdate.CountryId = updateContact.CountryId;
            }

            return _contactRepository.Update(contactToUpdate);

        }
    }
}
