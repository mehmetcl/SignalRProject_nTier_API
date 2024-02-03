using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.MessageDtos;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> MessageList()
        {
            var values = _messageService.GetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(MessageDto createMessageDto)
        {
            var mapMessage = _mapper.Map<Message>(createMessageDto); 
            await _messageService.AddAsync(mapMessage);     
            return Ok("Mesaj Başarılı Bir Şekilde Gönderildi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>  DeleteMessage(int id)
        {
            var value = await _messageService.GetByIdAsync(id);
            _messageService.RemoveAsync(value);
            return Ok("Mesaj Silindi");
        }
        [HttpPut]
        public async Task<IActionResult>  UpdateMessage(MessageDto updateMessageDto)
        {
            Message updateMessage = _mapper.Map<Message>(updateMessageDto);  
            await _messageService.UpdateAsync(updateMessage);
            return Ok("Mesaj Bilgisi Güncellendi");
        }
        [HttpGet("{id}")]
        public Task<IActionResult>  GetMessage(int id)
        {
            var value = _messageService.GetByIdAsync(id);
            return Task.FromResult<IActionResult>(Ok(value));
        }
    }
}
