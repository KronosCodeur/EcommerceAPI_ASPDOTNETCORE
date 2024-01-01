using Ecommerce_API.Models;

namespace Ecommerce_API.Repositories;

public interface IProductRepository
{
    Task<bool> CreateProduct(Product product);
    Task<List<Product>> GetAllProducts();
    Task<Product?> ProductInfo(int id);

}