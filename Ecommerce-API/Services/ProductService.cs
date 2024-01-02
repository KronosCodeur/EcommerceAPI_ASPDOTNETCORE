using AutoMapper;
using Ecommerce_API.Data;
using Ecommerce_API.DTO;
using Ecommerce_API.Models;
using Ecommerce_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services;

public class ProductService : IProductRepository
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public ProductService(DatabaseContext databaseContext, IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }

    public async Task<bool> CreateProduct(Product product)
    {
        await _databaseContext.Products.AddAsync(product);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        List<Product> products = await _databaseContext.Products.ToListAsync();
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