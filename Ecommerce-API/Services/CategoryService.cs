using Ecommerce_API.Data;
using Ecommerce_API.Models;
using Ecommerce_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services;

public class CategoryService : ICategoryRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly ProductService _productService;

    public CategoryService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> CreateCategory(Category category)
    {
        await _databaseContext.Categories.AddAsync(category);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        var categories = await _databaseContext.Categories.Include(category =>category.Products).ToListAsync();
        return categories;
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        var category = await _databaseContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        return category;
    }
}