using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        int GetTotalOrderCount();
        int GetActiveOrderCount();
        decimal GetLastOrderPrice();
        decimal GetTodayTotalPrice();



    }
}
