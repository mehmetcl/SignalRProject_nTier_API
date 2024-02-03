using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        Task<List<Product>> GetProductWithCategory();

        int ProductCount();

        int ProductCountByCategoryNameHamburger();

        int ProductCountByCategoryNameDrink();

        decimal ProductPriceAvg();

        string ProductNameByMaxPrice();

        string ProductNameByMinPrice();

        decimal ProductPriceByHamburger();

        decimal ProductPriceBySteakBurger();
        decimal TotalPriceByDrinkCategory();
        decimal TotalPriceBySaladCategory();

        decimal ProductAvgPriceByHamburger();
    }
}
