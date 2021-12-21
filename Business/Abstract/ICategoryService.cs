using Business.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Result<Category> AddCategory(Category category);
        Result<Category> UpdateCategory(int categoryId, Category category);
        Result<Category> DeleteCategory(int categoryId);
        Result<Category> HardDeleteCategory(int categoryId);
        Result<Category> GetCategoryById(int categoryId);
        Result<List<Category>> GetCategories();
    }
}
