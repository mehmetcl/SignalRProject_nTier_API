using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;
        private readonly IMoneyCasesService _moneyCasesService;

        public OrderController(IOrderService OrderService, IMapper mapper, SignalRContext context, IMoneyCasesService moneyCasesService)
        {
            _OrderService = OrderService;
            _mapper = mapper;
            _context = context;
            _moneyCasesService = moneyCasesService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_OrderService.GetTotalOrderCount());
        }


        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_OrderService.GetActiveOrderCount());
        }

        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_OrderService.GetTodayTotalPrice());
        }





    }
}
