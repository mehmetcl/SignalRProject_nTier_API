using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        Task<List<Product>> GetProductWithCategoryAsync();

        int GetProductCount();

        int GetProductCountByCategoryNameDrink();
        int GetProductCountByCategoryNameHamburger();

        decimal GetProductPriceAvg();

        string GetProductNameByMinPrice();

        string GetProductNameByMaxPrice();
        decimal GetProductPriceByHamburger();

        decimal GetProductPriceBySteakBurger();

        decimal GetTotalPriceByDrinkCategory();

        decimal GetTotalPriceBySaladCategory();


        decimal GetProductAvgPriceByHamburger();
    }
}
