using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.BookingDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService BookingService, IMapper mapper)
        {
            _BookingService = BookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BookingList()
        {
            var values = await _BookingService.GetAllAsync();
            var BookingList = _mapper.Map<List<BookingDto>>(values);
            return Ok(BookingList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingDto createBookingDto)
        {
            var mappedBooking = _mapper.Map<Booking>(createBookingDto);
            await _BookingService.AddAsync(mappedBooking);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = await _BookingService.GetByIdAsync(id);
            await _BookingService.RemoveAsync(value);
            return Ok("Hakkımda Alanı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking(BookingDto updateBookingDto)
        {
            Booking updatedCategory = _mapper.Map<Booking>(updateBookingDto);
            await _BookingService.UpdateAsync(updatedCategory);
            return Ok("Hakkımda Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var value = _BookingService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}
