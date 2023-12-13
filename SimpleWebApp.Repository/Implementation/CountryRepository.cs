using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.Models;
using SimpleWebApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SimpleWebApp.Repository.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Country> _entities;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<Country>();
        }

        public int Create(Country country)
        {
            _entities.Add(country);
            _context.SaveChanges();

            return country.CountryId;
        }

        public void Delete(Country country)
        {
            _entities.Remove(country);
            _context.SaveChanges();
        }

        public ICollection<Country> GetAll()
        {
            return _entities.ToList();
        }

        public Country? GetById(int? id)
        {
            return _entities.Find(id);
        }

        public Country Update(Country country)
        {
            _entities.Update(country);
            _context.SaveChanges();
            return country;
        }
    }
}
