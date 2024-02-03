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
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderService(IGenericDal<Order> genericDal, IUnitOfWork unitOfWork, IOrderDal orderDal) : base(genericDal, unitOfWork)
        {
            _orderDal = orderDal;
        }

        public int GetActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public int GetTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public decimal GetLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public decimal GetTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }
    }
}
