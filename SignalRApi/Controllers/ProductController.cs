using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Concrete;
using SignalRApi.Dtos.CategoryDtos;
using SignalRApi.Dtos.ProductDtos;


namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        private readonly SignalRContext _context;

        public ProductController(IProductService ProductService, IMapper mapper, SignalRContext context)
        {
            _ProductService = ProductService;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var Categories = await _ProductService.GetAllAsync();
            var ProductDtos = _mapper.Map<List<ProductDto>>(Categories).ToList();

            return Ok(ProductDtos);


        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto createProductDto)
        {
            var Product = createProductDto;
            var mappedProduct = _mapper.Map<Product>(Product);
            await _ProductService.AddAsync(mappedProduct);
            return Ok("Kategori Eklendi");

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Product value = await _ProductService.GetByIdAsync(id);
            ProductDto returnValue = _mapper.Map<ProductDto>(value);
            return Ok(returnValue);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await _ProductService.GetByIdAsync(id);
            await _ProductService.RemoveAsync(value);
            return Ok("Kategori silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDto updateProductDto)
        {

            Product updatedProduct = _mapper.Map<Product>(updateProductDto);


            await _ProductService.UpdateAsync(updatedProduct);

            return Ok("Kategori Güncellendi");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = _context;
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                Id = y.Id,
                Name = y.Name,
                Status = y.Status,
                CategoryName = y.Category.Name,
                CategoryId = y.CategoryId
            });
            return Ok(values.ToList());
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_ProductService.GetProductCount());
        }

        [HttpGet("GetProductCountByCategoryNameHamburger")]
        public IActionResult GetProductCountByCategoryNameHamburger()
        {
            return Ok(_ProductService.GetProductCountByCategoryNameHamburger());
        }
        [HttpGet("GetProductCountByCategoryNameDrink")]
        public IActionResult GetProductCountByCategoryNameDrink()
        {
            return Ok(_ProductService.GetProductCountByCategoryNameDrink());
        }

        [HttpGet("GetProductPriceAvg")]
        public IActionResult GetProductPriceAvg()
        {
            return Ok(_ProductService.GetProductPriceAvg());
        }
        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_ProductService.GetProductNameByMinPrice());
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_ProductService.GetProductNameByMaxPrice());
        }
        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            return Ok(_ProductService.GetProductAvgPriceByHamburger());
        }

        [HttpGet("GetProductPriceByHamburger")]
        public IActionResult GetProductPriceByHamburger()
        {
            return Ok(_ProductService.GetProductPriceByHamburger());
        }

        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_ProductService.GetProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_ProductService.GetProductPriceAvg());
        }

        [HttpGet("ProductPriceBySteakBurger")]
        public IActionResult ProductPriceBySteakBurger()
        {
            return Ok(_ProductService.GetProductPriceBySteakBurger());
        }
    }
}