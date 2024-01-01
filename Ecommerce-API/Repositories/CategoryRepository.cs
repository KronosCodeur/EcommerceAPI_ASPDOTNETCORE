using Ecommerce_API.Models;

namespace Ecommerce_API.Repositories;

public interface ICategoryRepository
{
    Task<bool> CreateCategory(Category category);
    Task<List<Category>> GetAllCategories();
    Task<Category?> GetCategoryById(int id);
}