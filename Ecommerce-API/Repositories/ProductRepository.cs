using Ecommerce_API.DTO;
using Ecommerce_API.Models;

namespace Ecommerce_API.Repositories;

public interface IProductRepository
{
    Task<bool> CreateProduct(Product product);
    Task<List<ProductDto>> GetAllProducts();
    Task<List<Product>> FindByCategory(Category category);
    Task<Product?> ProductInfo(int id);

}