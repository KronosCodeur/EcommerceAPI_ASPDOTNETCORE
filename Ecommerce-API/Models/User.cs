using System.ComponentModel.DataAnnotations;

namespace Ecommerce_API.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = String.Empty;
    public string Address { get; set; }
    public string Email { get; set; }
    public string? Token { get; set; }
}