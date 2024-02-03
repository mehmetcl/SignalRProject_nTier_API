using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _OrderDetailService;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;

        public OrderDetailController(IOrderDetailService OrderDetailService, IMapper mapper, SignalRContext context)
        {
            _OrderDetailService = OrderDetailService;
            _mapper = mapper;
            _context = context;
        }
      
    }
}
