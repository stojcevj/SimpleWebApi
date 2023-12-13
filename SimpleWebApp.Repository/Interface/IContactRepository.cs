using SimpleWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApp.Repository.Interface
{
    public interface IContactRepository
    {
        ICollection<Contact> GetAll();
        int Create(Contact contact);
        Contact Update(Contact contact);
        void Delete(Contact contact);
        ICollection<Contact> GetContactsWithCompanyAndCountry();
        ICollection<Contact> FilterContactByCountryIdAndCompanyId(int? countryId, int? companyId);
        ICollection<Contact> FilterContactByCountryId(int? countryId);
        ICollection<Contact> FilterContactByCompanyId(int? companyId);
        Contact? GetById(int? contactId);
    }
}
