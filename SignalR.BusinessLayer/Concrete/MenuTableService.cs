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
    public class MenuTableService : GenericService<MenuTable>, IMenuTableService
    {
      
        private readonly IMenuTableDal _menuTableDal;
        public MenuTableService(IGenericDal<MenuTable> genericDal, IUnitOfWork unitOfWork, IMenuTableDal menuTableDal) : base(genericDal, unitOfWork)
        {
            _menuTableDal = menuTableDal;
        }

        public int GetMenuTableCount()
        {
            return _menuTableDal.MenuTableCount();
        }
    }
}
