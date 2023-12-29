using Ecommerce_API.DTO;
using Ecommerce_API.Models;

namespace Ecommerce_API.Repositories;

public interface IUserRepository
{
    Task<bool> Register(User user);

}