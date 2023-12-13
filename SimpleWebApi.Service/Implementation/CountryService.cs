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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public int Create(AddCountryDTO addCountry)
        {
            if (addCountry == null) throw new ArgumentNullException("Country is Null");

            Country country = new Country()
            {
                CountryName = addCountry.CountryName,
            };

            return _countryRepository.Create(country);
        }

        public void Delete(int? countryId)
        {
            if (countryId == null) throw new ArgumentNullException("Country is Null");

            var country = _countryRepository.GetById(countryId);
            if (country == null)
                throw new Exception("Country cannot be found");

            _countryRepository.Delete(country);
        }

        public ICollection<Country> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public Country GetById(int? countryId)
        {
            if (countryId == null) throw new ArgumentNullException("Country is Null");

            var country = _countryRepository.GetById(countryId);

            if (country == null) throw new Exception("Country cannot be found");

            return country;
        }

        public Country Update(int? id, UpdateCountryDTO country)
        {
            var countryToUpdate = _countryRepository.GetById(id);

            if (countryToUpdate == null)
                throw new Exception("Country not found");

            if (country == null)
                throw new Exception("Country is Null");

            countryToUpdate.CountryName = country.CountryName;

            return _countryRepository.Update(countryToUpdate);
        }
    }
}
