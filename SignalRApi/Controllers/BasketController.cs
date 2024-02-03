using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.BasketDtos;
using SignalRApi.Dtos.ProductDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly SignalRContext _context;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper, SignalRContext context)
        {
            _basketService = basketService;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            var Basket = createBasketDto;
            var mappedBasket = _mapper.Map<Basket>(Basket);
            await _basketService.AddAsync(mappedBasket);
            return Ok("Sepet Eklendi");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _basketService.GetByIdAsync(id);
            await _basketService.RemoveAsync(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");

        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {

            var values = _context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                MenuTableID = z.MenuTableID,
                Count = z.Count,
                Id = z.Id,
                Price = z.Price,
                ProductID = z.ProductID,
                ProductName =z.Product.Name,
                TotalPrice = z.TotalPrice

            }).ToList();
            return Ok(values);
        }
    }
}
