using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleWebApi.Domain.DTO;
using SimpleWebApi.Domain.Models;
using SimpleWebApi.Service.Implementation;
using SimpleWebApi.Service.Interface;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] AddContactDTO addContact)
        {
            int createdContact = _contactService.Create(addContact);
            return Ok(createdContact);
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var jsonResult = JsonConvert.SerializeObject(_contactService.GetAll(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteContact(int id) 
        {
            _contactService.Delete(id);
            return Ok("Contact with Id: " + id + " is deleted.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] UpdateContactDTO updateContact)
        {
            var jsonResult = JsonConvert.SerializeObject(_contactService.Update(id, updateContact), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }
        [HttpGet("filter")]
        public IActionResult FilterContacts([FromQuery] int? countryId, [FromQuery] int? companyId)
        {
            var jsonResult = JsonConvert.SerializeObject(_contactService.FilterContact(countryId, companyId), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }
        [HttpGet("contactsWithCompanyAndCountry")]
        public IActionResult GetAllContactsWithCompanyAndCountry()
        {
            var jsonResult = JsonConvert.SerializeObject(_contactService.GetContactsWithCompanyAndCountry(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Ok(jsonResult);
        }
    }
}
