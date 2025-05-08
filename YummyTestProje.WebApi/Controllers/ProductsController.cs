using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyTestProje.WebApi.Context;
using YummyTestProje.WebApi.DTO.ProductDTO;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<CreateProductDTO> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<CreateProductDTO> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            var value = _context.Products.ToList();
            return Ok(value);
        }

        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {
            var value = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDTO>>(value));
        }
        

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDTO createProductDTO)
        {

            var value = _mapper.Map<Product>(createProductDTO);
            var result = _validator.Validate(createProductDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(value);
                _context.SaveChanges();
                return Ok("Urun ekleme basarili");
            }



        }
    }
}
