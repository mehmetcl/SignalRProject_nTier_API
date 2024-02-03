using Microsoft.Extensions.Options;
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
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategory()
        {
            return _context.Categories.Where(x => x.Status==true).Count();
        }

        public int CategoryCount()
        {
            return _context.Categories.Count();
        }

        public int PassiveCategory()
        {
           return _context.Categories.Where(x=>x.Status==false).Count();    
        }
    }
}
