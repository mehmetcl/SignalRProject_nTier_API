using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.CategoryDtos;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var Categories = await _categoryService.GetAllAsync();
            var CategoryDtos = _mapper.Map<List<CategoryDto>>(Categories).ToList();

            return Ok(CategoryDtos);


        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto createcategoryDto)
        {
            var category = createcategoryDto;
            var mappedCategory = _mapper.Map<Category>(category);
            await _categoryService.AddAsync(mappedCategory);
            return Ok("Kategori Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            Category value = await _categoryService.GetByIdAsync(id);
            CategoryDto returnValue = _mapper.Map< CategoryDto> (value);
            return Ok(returnValue);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(value);
            return Ok("Kategori silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto updateCategoryDto)
        {
         
            Category updatedCategory = _mapper.Map<Category>(updateCategoryDto);


            await _categoryService.UpdateAsync(updatedCategory);

            return Ok("Kategori Güncellendi");
        }
        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {

            return Ok(_categoryService.GetCategoryCount());
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.ActiveCategory());
        }
        [HttpGet("PassiveGetCategoryCount")]
        public IActionResult PassiveGetCategoryCount()
        {
            return Ok(_categoryService.PassiveCategory());
        }
    }
}
