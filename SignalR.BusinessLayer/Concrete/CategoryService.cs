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
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryService(IGenericDal<Category> genericDal, IUnitOfWork unitOfWork, ICategoryDal categoryDal) : base(genericDal, unitOfWork)
        {
            _categoryDal = categoryDal;
        }

        public int ActiveCategory()
        {
            return _categoryDal.ActiveCategory();   
        }
        public int PassiveCategory()
        {
            return _categoryDal.PassiveCategory();
        }
        public int GetCategoryCount()
        {
            return _categoryDal.CategoryCount();
        }

    

     
    }
}
