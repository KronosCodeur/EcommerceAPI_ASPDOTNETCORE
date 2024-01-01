using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Ecommerce_API.Data;
using Ecommerce_API.Models;
using Ecommerce_API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce_API.Services;

public class UserService : IUserRepository
{
    private readonly DatabaseContext _databaseContext;

    public UserService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> Register(User user)
    {
        _databaseContext.Users.Add(user);
        await _databaseContext.SaveChangesAsync();
        return true;
    }

    public async Task<User?> Login(string username)
    {
        var user = await _databaseContext.Users.FirstOrDefaultAsync(u=>u.Username==username);
        return user;
    }
    public string CreateUserToken(User user)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Username)
        };
        var key = new SymmetricSecurityKey(GenerateStrongKey(512));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );
        string jwt = new JwtSecurityTokenHandler().WriteToken(token);
        user.Token = jwt;

        return jwt;
    }

    private byte[] GenerateStrongKey(int keySizeBits)
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var keyBytes = new byte[keySizeBits / 8];
            rng.GetBytes(keyBytes);
            return keyBytes;
        }
    }
}