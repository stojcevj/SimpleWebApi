using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.Models;
using SimpleWebApp.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApp.Repository.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Contact> _entities;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<Contact>();
        }

        public int Create(Contact contact)
        {
            _entities.Add(contact);
            _context.SaveChanges();

            return contact.ContactId;
        }

        public void Delete(Contact contact)
        {
            _entities.Remove(contact);
            _context.SaveChanges();
        }

        public ICollection<Contact> FilterContactByCompanyId(int? companyId)
        {
            return _entities.Where(s => s.CompanyId == companyId).ToList();
        }

        public ICollection<Contact> FilterContactByCountryId(int? countryId)
        {
            return _entities.Where(s => s.CountryId == countryId).ToList();
        }

        public ICollection<Contact> FilterContactByCountryIdAndCompanyId(int? countryId, int? companyId)
        {
            return _entities.Where(s => (s.CountryId == countryId) && (s.CompanyId == companyId)).ToList();
        }

        public ICollection<Contact> GetAll()
        {
            return _entities.ToList();
        }

        public Contact? GetById(int? id)
        {
            return _entities.Find(id);
        }

        public ICollection<Contact> GetContactsWithCompanyAndCountry()
        {
            return _entities
                .Include(s => s.Company)
                .Include(s => s.Country)
                .ToList();
        }

        public Contact Update(Contact contact)
        {
            _entities.Update(contact);
            _context.SaveChanges();
            return contact;
        }
    }
}
