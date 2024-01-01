using Ecommerce_API.Data;
using Ecommerce_API.Models;
using Ecommerce_API.Repositories;

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
        await _databaseContext.AddAsync(product);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> ProductInfo(int id)
    {
        throw new NotImplementedException();
    }
}