using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryMenager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryMenager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetCategories()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetCategory(int categoryId)
        {
            return new  SuccessDataResult<Category>(_categoryDal.Get(p => p.CategoryId == categoryId));
        }
    }
}
