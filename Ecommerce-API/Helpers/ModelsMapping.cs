using AutoMapper;
using Ecommerce_API.DTO;
using Ecommerce_API.Models;

namespace Ecommerce_API.Helpers;

public class ModelsMapping : Profile
{
    public ModelsMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}