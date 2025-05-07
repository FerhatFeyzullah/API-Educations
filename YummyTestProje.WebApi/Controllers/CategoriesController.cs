using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyTestProje.WebApi.Context;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Ekleme Islemi Basarili");
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _context.Categories.ToList();
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori Silme Islemi Basarili");
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori Guncelleme Islemi Basarili");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) 
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }
    }
}
