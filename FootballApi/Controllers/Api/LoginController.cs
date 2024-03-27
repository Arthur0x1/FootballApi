using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace FootballApi.Controllers.Api;

[ApiController]
[Route("/api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _config;

    public LoginController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IConfiguration config
    )
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _config = config;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] LoginDto model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);
        if (!result.Succeeded) throw new ApplicationException("INVALID_LOGIN_ATTEMPT");

        var appUser = _userManager.Users.SingleOrDefault(u => u.Email == model.Email);
        return GenerateJwtToken(model.Email!, appUser!);

    }

    private object GenerateJwtToken(string email, IdentityUser user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:JwtKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["JwtConfig:JwtExpireDays"]!));

        var issuer = _config["JwtConfig:JwtIssuer"]!;
        var token = new JwtSecurityToken(
            issuer,
            issuer,
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public class LoginDto
    {
        [Required] public string? Email { get; set; }
        [Required] public string? Password { get; set; }
    }
}