using AutoMapper;
using Ecommerce_API.DTO;
using Ecommerce_API.Models;

namespace Ecommerce_API.Helpers;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();

    }
}