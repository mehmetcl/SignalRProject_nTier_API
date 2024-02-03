using SignalR.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public int GetCategoryCount();

        public int PassiveCategory();

        public int ActiveCategory();

    }
}
