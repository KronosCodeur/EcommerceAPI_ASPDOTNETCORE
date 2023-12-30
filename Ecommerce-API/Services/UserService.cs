using Ecommerce_API.Data;
using Ecommerce_API.Models;
using Ecommerce_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Services;

public class UserService : IUserRepository
{
    private readonly UserDbContext _userDbContext;

    public UserService(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public async Task<bool> Register(User user)
    {
        _userDbContext.Users.Add(user);
        await _userDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<User?> Login(string username)
    {
        var user = await _userDbContext.Users.FirstOrDefaultAsync(u=>u.Username==username);
        return user;
    }
}