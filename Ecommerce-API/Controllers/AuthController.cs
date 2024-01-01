using AutoMapper;
using Ecommerce_API.Data;
using Ecommerce_API.DTO;
using Ecommerce_API.Models;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    private readonly UserService _userService;
    private readonly DatabaseContext _databaseContext;
    private readonly IMapper _mapper;

    public AuthController(UserService userService, IMapper mapper, DatabaseContext databaseContext)
    {
        _userService = userService;
        _mapper = mapper;
        _databaseContext = databaseContext;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        user.Password = passwordHash;
        bool result = await _userService.Register(user);
        if (!result)
        {
            return BadRequest();
        }
        return StatusCode(201, "You  are successfully registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)

    {
        var user = await _userService.Login(username);
        if (user is null)
        {
            return StatusCode(404, "Invalid username.");
        }
        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return StatusCode(404, "Invalid password.");
        }

        user.Token = _userService.CreateUserToken(user);
        _databaseContext.Users.Update(user);
        await _databaseContext.SaveChangesAsync();
        var data = new Dictionary<string, string>()
        {
            {"id",user.ID.ToString()},
            {"username",username},
            {"address",user.Address},
            {"email",user.Email},
            {"token",user.Token},
        };
        return Ok(data);
    }
}