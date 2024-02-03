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
    public class MoneyCasesService : GenericService<MoneyCase>, IMoneyCasesService
    {
        private readonly IMoneyCasesDal _moneyCasesDal;
        public MoneyCasesService(IGenericDal<MoneyCase> genericDal, IUnitOfWork unitOfWork, IMoneyCasesDal moneyCasesDal) : base(genericDal, unitOfWork)
        {
            _moneyCasesDal = moneyCasesDal;
        }

        public decimal GetCurrentCash()
        {
         return _moneyCasesDal.CurrentCash();
        }

        public decimal GetTotalMoneyCaseAmount()
        {
           return _moneyCasesDal.TotalMoneyCaseAmount();
        }
    }
}
