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
        private readonly IValidator<CreateProductDTO> _validatorCreate;
        private readonly IValidator<UpdateProductDTO> _validatorUpdate;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<CreateProductDTO> validator, ApiContext context, IMapper mapper, IValidator<UpdateProductDTO> validatorUpdate)
        {
            _validatorCreate = validator;
            _context = context;
            _mapper = mapper;
            _validatorUpdate = validatorUpdate;
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
            var result = _validatorCreate.Validate(createProductDTO);
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

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var value = _mapper.Map<Product>(updateProductDTO);
            var result = _validatorUpdate.Validate(updateProductDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(value);
                _context.SaveChanges();
                return Ok("Urun Guncelleme basarili");
            }

        }
    }
}
