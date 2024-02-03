using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.ContactDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var Categories = await _ContactService.GetAllAsync();
            var ContactDtos = _mapper.Map<List<ContactDto>>(Categories).ToList();

            return Ok(ContactDtos);


        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDto createContactDto)
        {
            var Contact = createContactDto;
            var mappedContact = _mapper.Map<Contact>(Contact);
            await _ContactService.AddAsync(mappedContact);
            return Ok("Kategori Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            Contact value = await _ContactService.GetByIdAsync(id);
            ContactDto returnValue = _mapper.Map<ContactDto>(value);
            return Ok(returnValue);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _ContactService.GetByIdAsync(id);
            await _ContactService.RemoveAsync(value);
            return Ok("Kategori silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(ContactDto updateContactDto)
        {

            Contact updatedContact = _mapper.Map<Contact>(updateContactDto);


            await _ContactService.UpdateAsync(updatedContact);

            return Ok("Kategori Güncellendi");
        }

    }
}
