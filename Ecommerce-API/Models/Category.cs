namespace Ecommerce_API.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Product> products { get; set; }

    public Category(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}