using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Domain.Models;
using SimpleWebApi.Service.Implementation;
using SimpleWebApi.Service.Interface;

namespace SimpleWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] AddCompanyDTO addCompany)
        {
            int createdCompany = _companyService.Create(addCompany);
            return Ok(createdCompany);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jsonResult = JsonConvert.SerializeObject(_companyService.GetAll(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            _companyService.Delete(id);
            return Ok("Company with Id: " + id + " is deleted.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComapny(int id, [FromBody] UpdateCompanyDTO updateCompany)
        {
            var jsonResult = JsonConvert.SerializeObject(_companyService.Update(id, updateCompany), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }

    }
}
