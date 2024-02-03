using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.TestimonialDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _TestimonialService = TestimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var Categories = await _TestimonialService.GetAllAsync();
            var TestimonialDtos = _mapper.Map<List<TestimonialDto>>(Categories).ToList();

            return Ok(TestimonialDtos);


        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(TestimonialDto createTestimonialDto)
        {
            var Testimonial = createTestimonialDto;
            var mappedTestimonial = _mapper.Map<Testimonial>(Testimonial);
            await _TestimonialService.AddAsync(mappedTestimonial);
            return Ok("Kategori Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            Testimonial value = await _TestimonialService.GetByIdAsync(id);
            TestimonialDto returnValue = _mapper.Map<TestimonialDto>(value);
            return Ok(returnValue);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var value = await _TestimonialService.GetByIdAsync(id);
            await _TestimonialService.RemoveAsync(value);
            return Ok("Kategori silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(TestimonialDto updateTestimonialDto)
        {

            Testimonial updatedTestimonial = _mapper.Map<Testimonial>(updateTestimonialDto);


            await _TestimonialService.UpdateAsync(updatedTestimonial);

            return Ok("Kategori Güncellendi");
        }


    }
}
