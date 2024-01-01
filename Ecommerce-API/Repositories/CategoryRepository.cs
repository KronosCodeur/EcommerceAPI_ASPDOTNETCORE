using Ecommerce_API.Models;

namespace Ecommerce_API.Repositories;

public interface ICategoryRepository
{
    Task<Category> CreateCategory(Category category);
    Task<List<Category>> GetAllCategories();
}