using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;

namespace Ecommerce_API.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public double Price { get; set; }


}