using SimpleWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApp.Repository.Interface
{
    public interface ICompanyRepository
    {
        ICollection<Company> GetAll();
        int Create(Company company);
        Company Update(Company company);
        void Delete(Company company);
        Company? GetById(int? id);
    }
}
