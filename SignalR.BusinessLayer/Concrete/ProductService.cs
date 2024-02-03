using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IGenericDal<Product> genericDal, IUnitOfWork unitOfWork, IProductDal productDal) : base(genericDal, unitOfWork)
        {
            _productDal = productDal;
        }

        public int GetProductCount()
        {
            return _productDal.ProductCount();
        }

        public int GetProductCountByCategoryNameDrink()
        {
            return _productDal.ProductCountByCategoryNameDrink();
        }

        public int GetProductCountByCategoryNameHamburger()
        {
            return _productDal.ProductCountByCategoryNameHamburger();
        }

        public decimal GetProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public Task<List<Product>> GetProductWithCategoryAsync()
        {
            return _productDal.GetProductWithCategory();
        }


        

        string IProductService.GetProductNameByMinPrice()
        {
            return _productDal.ProductNameByMinPrice();
        }

        public string GetProductNameByMaxPrice()
        {
            return _productDal.ProductNameByMaxPrice();
        }

        public decimal GetProductPriceByHamburger()
        {
            return _productDal.ProductPriceByHamburger();
        }

        public decimal GetProductPriceBySteakBurger()
        {
            return _productDal.ProductPriceBySteakBurger();
        }

        public decimal GetTotalPriceByDrinkCategory()
        {
            return _productDal.TotalPriceByDrinkCategory();
        }

        public decimal GetTotalPriceBySaladCategory()
        {
            return _productDal.TotalPriceBySaladCategory();
        }

        public decimal GetProductAvgPriceByHamburger()
        {
            return _productDal.ProductAvgPriceByHamburger();
        }
    }
}
