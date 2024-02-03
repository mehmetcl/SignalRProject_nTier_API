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
    public class EFMoneyCasesDal : GenericRepository<MoneyCase>, IMoneyCasesDal
    {
     

        public EFMoneyCasesDal(SignalRContext context) : base(context)
        {
        }

        public decimal CurrentCash()
        {
           
            var totalAmount = _context.Orders.Where(x => x.Description == "Hesap Kapatıldı").Sum(x => x.TotalPrice);

            return totalAmount;
        }

        public decimal TotalMoneyCaseAmount()
        {
            return _context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();   
        }
    }

}
