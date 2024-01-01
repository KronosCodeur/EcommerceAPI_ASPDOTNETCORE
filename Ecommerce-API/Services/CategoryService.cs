using Ecommerce_API.Data;
using Ecommerce_API.Models;
using Ecommerce_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services;

public class CategoryService : ICategoryRepository
{
    private readonly DatabaseContext _databaseContext;

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
        var categories = await _databaseContext.Categories.ToListAsync();
        return categories;
    }
}