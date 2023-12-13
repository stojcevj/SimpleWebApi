using SimpleWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApp.Repository.Interface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetAll();
        int Create(Country country);
        Country Update(Country country);
        void Delete(Country countryId);
        Country? GetById(int? id);
    }
}
