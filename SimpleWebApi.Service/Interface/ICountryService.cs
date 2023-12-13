using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Service.Interface
{
    public interface ICountryService
    {
        int Create(AddCountryDTO addCountry);
        Country Update(int? id, UpdateCountryDTO country);
        void Delete(int? countryId);
        ICollection<Country> GetAll();
        Country GetById(int? countryId);
    }
}
