using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.MenuTableDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.GetMenuTableCount());
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.GetAllAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(MenuTableDto createMenuTableDto)
        {
            var mapmenuTable = _mapper.Map<MenuTable>(createMenuTableDto);
            await _menuTableService.AddAsync(mapmenuTable);
            return Ok("Masa Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            var value = await _menuTableService.GetByIdAsync(id);
            await _menuTableService.RemoveAsync(value);
            return Ok("Masa Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenuTable(MenuTableDto updateMenuTableDto)
        {
            var updatemapmenuTable = _mapper.Map<MenuTable>(updateMenuTableDto);
            await _menuTableService.UpdateAsync(updatemapmenuTable);
            return Ok("Masa Bilgisi Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}
