using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.FeatureDtos;
using SignalRApi.Dtos.ProductDtos;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;

        public FeatureController(IFeatureService FeatureService, IMapper mapper, SignalRContext context)
        {
            _FeatureService = FeatureService;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var Categories = await _FeatureService.GetAllAsync();
            var FeatureDtos = _mapper.Map<List<FeatureDto>>(Categories).ToList();

            return Ok(FeatureDtos);


        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(FeatureDto createFeatureDto)
        {
            var Feature = createFeatureDto;
            var mappedFeature = _mapper.Map<Feature>(Feature);
            await _FeatureService.AddAsync(mappedFeature);
            return Ok("Kategori Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            Feature value = await _FeatureService.GetByIdAsync(id);
            FeatureDto returnValue = _mapper.Map<FeatureDto>(value);
            return Ok(returnValue);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var value = await _FeatureService.GetByIdAsync(id);
            await _FeatureService.RemoveAsync(value);
            return Ok("Kategori silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(FeatureDto updateFeatureDto)
        {

            Feature updatedFeature = _mapper.Map<Feature>(updateFeatureDto);


            await _FeatureService.UpdateAsync(updatedFeature);

            return Ok("Kategori Güncellendi");
        }

     


    }
}
