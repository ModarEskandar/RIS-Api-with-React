using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Data.DTOs;
using Data.IRepository;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Services;

public class AuthManager : IAuthManager
{
    private readonly ILogger<AuthManager> _logger;
    private readonly ApiUser _apiUser;
    private readonly UserManager<ApiUser> _userManager;
    private readonly IConfiguration _configuration;
    public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration, ILogger<AuthManager> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _userManager = userManager;
        // _signInManager = signInManager;
    }
    public async Task<bool> ValidateUser(LoginUserDTO userDTO)
    {
        var _apiUser = await _userManager.FindByNameAsync(userDTO.Email);
        var passwordResult = await _userManager.CheckPasswordAsync(_apiUser, userDTO.Password);
        _logger.LogInformation($"AuthManager attempt from {userDTO.Email} ");

        return (_apiUser != null && passwordResult);
    }
    public async Task<string> CreateToken()
    {

        SigningCredentials signingCredentials = GetsigningCredentials();
        List<Claim> claims = await GetClaims();
        var token = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(token);

    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSetting = _configuration.GetSection("Jwt");
        var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSetting.GetSection("lifetime").Value));
        return new JwtSecurityToken(
            issuer: jwtSetting.GetSection("Issuer").Value,
            claims: claims,
            expires: expiration,
signingCredentials: signingCredentials
        );
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>{
            new Claim(ClaimTypes.Name,_apiUser.UserName )
        };
        var roles = await _userManager.GetRolesAsync(_apiUser);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));

        }
        return claims;
    }

    private SigningCredentials GetsigningCredentials()
    {
        var key = Environment.GetEnvironmentVariable("Key");
        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
}