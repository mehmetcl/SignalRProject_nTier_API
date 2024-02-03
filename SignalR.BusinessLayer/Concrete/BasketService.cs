using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketService : GenericService<Basket>, IBasketService
    {
        private readonly IBasketDal _basketDal;
        public BasketService(IGenericDal<Basket> genericDal, IUnitOfWork unitOfWork, IBasketDal basketDal) : base(genericDal, unitOfWork)
        {
            _basketDal = basketDal;
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }
    }
}
