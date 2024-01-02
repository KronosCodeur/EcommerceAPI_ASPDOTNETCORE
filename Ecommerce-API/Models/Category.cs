using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecommerce_API.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; }

}