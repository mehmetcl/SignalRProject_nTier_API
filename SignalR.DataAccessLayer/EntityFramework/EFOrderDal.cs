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
    public class EFOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EFOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
           return _context.Orders.Where(x=>x.Status==true).Count();
        }

        public decimal LastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.Id).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {

            return _context.Orders.Where(x => x.Date == DateTime.Parse(DateTime.Now.ToShortDateString())).Sum(y => y.TotalPrice);

          
           
        }

        public int TotalOrderCount()
        {
          
            return _context.Orders.Count();
        }

      
    }
}
