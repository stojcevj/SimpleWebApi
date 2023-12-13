using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Domain.Models;
using SimpleWebApi.Service.Interface;
using SimpleWebApp.Repository.Implementation;
using SimpleWebApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SimpleWebApi.Service.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public int Create(AddCompanyDTO addCompany)
        {
            if (addCompany == null) throw new ArgumentNullException("Company is Null");

            Company company = new Company()
            {
                CompanyName = addCompany.CompanyName,
            };

            return _companyRepository.Create(company);
        }

        public void Delete(int? companyId)
        {
            if (companyId == null) throw new ArgumentNullException("Company is Null");

            var company = _companyRepository.GetById(companyId);
            if (company == null)
                throw new Exception("Company cannot be found");

            _companyRepository.Delete(company);
        }

        public ICollection<Company> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public Company GetById(int? companyId)
        {
            if (companyId == null) throw new ArgumentNullException("Company is Null");

            var company = _companyRepository.GetById(companyId);

            if (company == null) throw new Exception("Company cannot be found");

            return company;
        }

        public Company Update(int? id, UpdateCompanyDTO company)
        {
            var companyToUpdate = _companyRepository.GetById(id);

            if (companyToUpdate == null)
                throw new Exception("Company not found");

            if (company == null) 
                throw new ArgumentNullException("Company is Null");

            companyToUpdate.CompanyName = company.CompanyName;

            return _companyRepository.Update(companyToUpdate);
        }
    }
}
