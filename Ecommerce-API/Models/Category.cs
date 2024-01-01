namespace Ecommerce_API.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Product>? Products { get; set; }

    public Category(int id, string title, string description, List<Product>? products)
    {
        Id = id;
        Title = title;
        Description = description;
        Products = products;
    }
}