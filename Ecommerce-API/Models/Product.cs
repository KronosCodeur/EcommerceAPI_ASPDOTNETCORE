using AutoMapper.Configuration.Annotations;

namespace Ecommerce_API.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public double Price { get; set; }
}