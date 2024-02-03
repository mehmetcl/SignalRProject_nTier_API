using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.SocialMediaDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMedialService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMedialService SocialMediaService, IMapper mapper)
        {
            _SocialMediaService = SocialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var Categories = await _SocialMediaService.GetAllAsync();
            var SocialMediaDtos = _mapper.Map<List<SocialMediaDto>>(Categories).ToList();

            return Ok(SocialMediaDtos);


        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(SocialMediaDto createSocialMediaDto)
        {
            var SocialMedia = createSocialMediaDto;
            var mappedSocialMedia = _mapper.Map<SocialMedia>(SocialMedia);
            await _SocialMediaService.AddAsync(mappedSocialMedia);
            return Ok("Kategori Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            SocialMedia value = await _SocialMediaService.GetByIdAsync(id);
            SocialMediaDto returnValue = _mapper.Map<SocialMediaDto>(value);
            return Ok(returnValue);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var value = await _SocialMediaService.GetByIdAsync(id);
            await _SocialMediaService.RemoveAsync(value);
            return Ok("Kategori silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaDto updateSocialMediaDto)
        {

            SocialMedia updatedSocialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);


            await _SocialMediaService.UpdateAsync(updatedSocialMedia);

            return Ok("Kategori Güncellendi");
        }


    }
}
