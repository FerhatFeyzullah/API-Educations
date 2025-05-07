using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyTestProje.WebApi.Context;
using YummyTestProje.WebApi.DTO.ContactDTO;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
       private readonly ApiContext _context;

        public ContactController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetContact()
        {
            var value = _context.Contacts.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO dto)
        {
            Contact contact = new Contact
            {
                MapLocation = dto.MapLocation,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                OpenHours = dto.OpenHours
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Contact Ekleme Islemi Basarili.");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Contact Silme Islemi Basarili.");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO dto)
        {
           Contact contact = new Contact
           {
               ContactId = dto.ContactId,
               MapLocation = dto.MapLocation,
               Address = dto.Address,
               Phone = dto.Phone,
               Email = dto.Email,
               OpenHours = dto.OpenHours
           };
            
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Contact Guncelleme Islemi Basarili.");
        }


    }
}
