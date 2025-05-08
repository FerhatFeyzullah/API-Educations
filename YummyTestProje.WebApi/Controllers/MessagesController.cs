using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyTestProje.WebApi.Context;
using YummyTestProje.WebApi.DTO.MessageDTO;
using YummyTestProje.WebApi.Entities;

namespace YummyTestProje.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDTO>>(value));
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDTO>(value));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var value = _mapper.Map<Message>(createMessageDTO);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj Ekleme Islemi Basarili");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj Silme Islemi Basarili");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var value = _mapper.Map<Message>(updateMessageDTO);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Mesaj Güncelleme Islemi Basarili");
        }
    }
}
