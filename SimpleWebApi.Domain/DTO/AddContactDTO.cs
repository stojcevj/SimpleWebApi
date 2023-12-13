using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Domain.DTO
{
    public class AddContactDTO
    {
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
