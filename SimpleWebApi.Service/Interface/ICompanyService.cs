using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Service.Interface
{
    public interface ICompanyService
    {
        int Create(AddCompanyDTO addCompany);
        Company Update(int? id, UpdateCompanyDTO company);
        void Delete(int? companyId);
        ICollection<Company> GetAll();
        Company GetById(int? companyId);
    }
}
