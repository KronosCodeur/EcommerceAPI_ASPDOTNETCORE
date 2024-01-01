namespace Ecommerce_API.DTO;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public double Price { get; set; }
}