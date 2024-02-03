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
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCasesService _moneyCasesService;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;

        public MoneyCasesController(IMoneyCasesService MoneyCasesService, IMapper mapper, SignalRContext context)
        {
            _moneyCasesService = MoneyCasesService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("CurrentCashAmount")]
        public IActionResult CurrentCashAmount()
        {
            var currentCash = _moneyCasesService.GetCurrentCash();

            MoneyCase moneyCase = new MoneyCase();
            moneyCase.TotalAmount = currentCash;
            MoneyCase value = _mapper.Map<MoneyCase>(moneyCase);

            return Ok(currentCash);

        }

        [HttpGet("TotalMoneyCaseAmount")]
        public IActionResult TotalMoneyCaseAmount()
        {

            return Ok(_moneyCasesService.GetTotalMoneyCaseAmount());

        }
    }
}
