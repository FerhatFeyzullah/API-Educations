using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyTestProje.WebApi.Context;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetService()
        {
            var value = _context.Services.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateServices(Service service)
        {             
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Service Ekleme Islemi Basarili.");
        }

        [HttpDelete]
        public IActionResult DeleteServices(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Service Silme Islemi Basarili.");
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateServices(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Services Guncelleme Islemi Basarili.");
        }
    }
}
