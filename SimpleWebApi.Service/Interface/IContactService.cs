using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Service.Interface
{
    public interface IContactService
    {
        int Create(AddContactDTO addContact);
        Contact Update(int? id, UpdateContactDTO updateContact);
        void Delete(int? contactId);
        Contact GetById(int? contactId);
        ICollection<Contact> GetAll();
        ICollection<Contact> GetContactsWithCompanyAndCountry();
        ICollection<Contact> FilterContact(int? countryId, int? companyId);
    }
}
