namespace Ecommerce_API.DTO;

public class CategoryDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public CategoryDto(string title, string description)
    {
        Title = title;
        Description = description;
    }
}