using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {

        public EFProductDal(SignalRContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public decimal ProductAvgPriceByHamburger()
        {
            return _context.Products.Where(x => x.Category.Name == "Hamburger").Average(w => w.Price);

        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return _context.Products.Include(x => x.Category).Where(y => y.Category.Name == "İçecek").Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return _context.Products.Include(x => x.Category).Where(y => y.Category.Name == "Hamburger").Count();
        }

        public string ProductNameByMaxPrice()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Max(y => y.Price))).Select(z => z.Name).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            return _context.Products.Where(x => x.Price == (_context.Products.Min(y => y.Price))).Select(z => z.Name).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            return _context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceByHamburger()
        {
            return _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.Id).FirstOrDefault())).Average(w => w.Price);
        }

        public decimal ProductPriceBySteakBurger()
        {
            return _context.Products.Where(x => x.Name == "Steak Burger").Select(y => y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            int id = _context.Categories.Where(x => x.Name == "İçecek").Select(y => y.Id).FirstOrDefault();
            return _context.Products.Where(x => x.Id == id).Sum(y => y.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            int id = _context.Categories.Where(x => x.Name == "Salata").Select(y => y.Id).FirstOrDefault();
            return _context.Products.Where(x => x.Id == id).Sum(y => y.Price);
        }
    }
}

