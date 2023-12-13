using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.Models;
using SimpleWebApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SimpleWebApp.Repository.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Company> _entities;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<Company>();
        }

        public int Create(Company company)
        {
            _entities.Add(company);
            _context.SaveChanges();

            return company.CompanyId;
        }

        public void Delete(Company company)
        {
            _entities.Remove(company);
            _context.SaveChanges();
        }

        public ICollection<Company> GetAll()
        {
            return _entities.ToList();
        }

        public Company? GetById(int? id)
        {
            return _entities.Find(id);
        }

        public Company Update(Company company)
        {
            _entities.Update(company);
            _context.SaveChanges();
            return company;
        }
    }
}
