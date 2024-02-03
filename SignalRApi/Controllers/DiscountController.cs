using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.DiscountDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService DiscountService, IMapper mapper)
        {
            _DiscountService = DiscountService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountList()
        {
            var Categories = await _DiscountService.GetAllAsync();
            var DiscountDtos = _mapper.Map<List<DiscountDto>>(Categories).ToList();

            return Ok(DiscountDtos);


        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(DiscountDto createDiscountDto)
        {
            var Discount = createDiscountDto;
            var mappedDiscount = _mapper.Map<Discount>(Discount);
            await _DiscountService.AddAsync(mappedDiscount);
            return Ok("Kategori Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            Discount value = await _DiscountService.GetByIdAsync(id);
            DiscountDto returnValue = _mapper.Map<DiscountDto>(value);
            return Ok(returnValue);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var value = await _DiscountService.GetByIdAsync(id);
            await _DiscountService.RemoveAsync(value);
            return Ok("Kategori silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(DiscountDto updateDiscountDto)
        {

            Discount updatedDiscount = _mapper.Map<Discount>(updateDiscountDto);


            await _DiscountService.UpdateAsync(updatedDiscount);

            return Ok("Kategori Güncellendi");
        }


    }
}
