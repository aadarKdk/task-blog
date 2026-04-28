using Microsoft.AspNetCore.Mvc;
using TaskBlog.API.Helpers;
using TaskBlog.API.Services;
using TaskBlog.Application.DTOs;
using TaskBlog.Domain.Entities;
using TaskBlog.Infrastructure.Data;

namespace TaskBlog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwt;

    public AuthController(AppDbContext context, JwtService jwt)
    {
        _context = context;
        _jwt = jwt;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            PasswordHash = PasswordHasher.Hash(dto.Password),
            Role = "User",
            CreatedAt = DateTime.UtcNow,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var hash = PasswordHasher.Hash(dto.Password);

        var user = _context.Users.FirstOrDefault(u =>
            u.Username == dto.Username && u.PasswordHash == hash
        );

        if (user == null)
            return Unauthorized();

        var token = _jwt.GenerateToken(user);

        return Ok(new AuthResponseDto { Token = token });
    }
}
