using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Service.Implementation;
using SimpleWebApi.Service.Interface;

namespace SimpleWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] AddCountryDTO addCountry)
        {
            int createdCountry = _countryService.Create(addCountry);
            return Ok(createdCountry);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var jsonResult = JsonConvert.SerializeObject(_countryService.GetAll(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            _countryService.Delete(id);
            return Ok("Country with Id: " + id + " is deleted.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] UpdateCountryDTO updateCountry)
        {
            var jsonResult = JsonConvert.SerializeObject(_countryService.Update(id, updateCountry), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }
    }
}
