using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.AboutDtos;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GetAllAsync(); 
            var AboutList = _mapper.Map<List<AboutDto>>(values); 
            return Ok(AboutList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(AboutDto createAboutDto)
        {
            var mappedAbout = _mapper.Map<About>(createAboutDto);
            await _aboutService.AddAsync(mappedAbout);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var value = await _aboutService.GetByIdAsync(id);
            await _aboutService.RemoveAsync(value);
            return Ok("Hakkımda Alanı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(AboutDto updateAboutDto)
        {
            About updatedCategory = _mapper.Map<About>(updateAboutDto);
            await _aboutService.UpdateAsync(updatedCategory);
            return Ok("Hakkımda Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public Task<IActionResult> GetAbout(int id)
        {
            var value = _aboutService.GetByIdAsync(id);
            return Task.FromResult<IActionResult>(Ok(value));
        }
    }
}
