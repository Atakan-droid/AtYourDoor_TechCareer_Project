using Business.Abstract;
using Business.Utilities.Messages;
using Business.Utilities.Result;
using Business.Validation.FluentValidation;
using Data.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public Result<Category> AddCategory(Category Category)
        {
            var result = ValidateCategory(Category);
            if (result.IsValid)
            {
                _categoryDal.Add(Category);
                return new Result<Category>(Category, true, Messages.CategoryAdded);
            }
            else
            {
                List<string> errorList = new List<string>();
                foreach (var error in result.Errors)
                {
                    errorList.Add(error.PropertyName + " : " + error.ErrorMessage);
                }
                return new Result<Category>(errorList, false, Messages.CategoryError);
            }


        }
        public Result<Category> DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                category.Data.IsDeleted = true;
                category.Data.ModifiedDate = DateTime.Now;
                _categoryDal.Update(category.Data);
                return new Result<Category>(category.Data, true, Messages.RoleDeleted);
            }
            else
            {
                return new Result<Category>(false, Messages.CategoryNotFound);
            }
        }
        public Result<Category> HardDeleteCategory(int CategoryId)
        {
            var Category = GetCategoryById(CategoryId);
            if (Category != null)
            {
                _categoryDal.Delete(Category.Data);
                return new Result<Category>(true, Messages.RoleDeleted);
            }
            else
            {
                return new Result<Category>(false, Messages.CategoryNotFound);
            }
        }

        public Result<Category> UpdateCategory(int categoryId, Category category)
        {

            var CategoryToUpdate = GetCategoryById(categoryId);
                if (CategoryToUpdate.Success)
                {
                    CategoryToUpdate.Data.Name = category.Name;
                    CategoryToUpdate.Data.IsDeleted = category.IsDeleted;
                    CategoryToUpdate.Data.ModifiedDate = DateTime.Now;
                    _categoryDal.Update(CategoryToUpdate.Data);
                    return new Result<Category>(CategoryToUpdate.Data, true, Messages.CategoryUpdated);
                }
                return new Result<Category>(false, Messages.CategoryNotFound);
          
        }

        public Result<Category> GetCategoryById(int CategoryId)
        {
            Category Category = _categoryDal.Get(p => p.Id == CategoryId && p.IsDeleted == false);
            if (Category != null)
            {
                return new Result<Category>(Category, true, Messages.CategoryGet);
            }
            else
            {
                return new Result<Category>(false, Messages.CategoryNotFound);
            }
        }

        public Result<List<Category>> GetCategories()
        {
            return new Result<List<Category>>(_categoryDal.GetAll(null,c=>c.Products), true, Messages.CategoryGet);
        }


        private ValidationResult ValidateCategory(Category category)
        {
            CategoryValidation rules = new CategoryValidation();
            ValidationResult result = rules.Validate(category);
            return result;
        }
    }
}
