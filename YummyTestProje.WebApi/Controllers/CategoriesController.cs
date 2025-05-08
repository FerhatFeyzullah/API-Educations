using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyTestProje.WebApi.Context;
using YummyTestProje.WebApi.DTO.CategoryDTO;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var value = _mapper.Map<Category>(createCategoryDTO);
            _context.Categories.Add(value);
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
