using System.Collections.Generic;
using ComputerStore.Services.DTOs;

namespace ComputerStore.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAllCategories();
        CategoryDTO GetCategoryById(int id);
        CategoryDTO AddCategory(CategoryDTO category);
        CategoryDTO UpdateCategory(CategoryDTO category);
        bool DeleteCategory(int id);
    }
}