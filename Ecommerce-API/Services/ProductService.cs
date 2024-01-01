using Ecommerce_API.Data;
using Ecommerce_API.Models;
using Ecommerce_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services;

public class ProductService : IProductRepository
{
    private readonly DatabaseContext _databaseContext;

    public ProductService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> CreateProduct(Product product)
    {
        var categories = await _databaseContext.Categories.ToListAsync();
        foreach (var category in categories)
        {
            var products = await _databaseContext.Products.Where(p=>p.Category==category).ToListAsync();
            category.Products = products;
            _databaseContext.Categories.Update(category);
        }
        await _databaseContext.Products.AddAsync(product);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        products = await _databaseContext.Products.ToListAsync();
        return products;
    }

    public async Task<List<Product>> FindByCategory(Category category)
    {
        var products = await _databaseContext.Products.Where(p=>p.Category==category).ToListAsync();

        return products;
    }

    public async Task<Product?> ProductInfo(int id)
    {
        return await _databaseContext.Products.FirstOrDefaultAsync(p=>p.Id==id);
    }
}