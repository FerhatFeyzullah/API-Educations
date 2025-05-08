using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyTestProje.WebApi.Context;
using YummyTestProje.WebApi.DTO.FeatureDTO;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFeatures()
        {
            var value = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDTO>>(value));
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
           var value = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDTO>(value));
           
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            var value = _mapper.Map<Feature>(createFeatureDTO);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme Islemi Basarili");

        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme Islemi Basarili");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            var value = _mapper.Map<Feature>(updateFeatureDTO);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Guncelleme Islemi Basarili");


        }


    }
}
