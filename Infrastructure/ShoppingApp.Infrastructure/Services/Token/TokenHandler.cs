using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingApp.Application.Abstractions.Token;
using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Application.DTOs.Token CreateAccessToken(int minute, AppUser user)
    {
        Application.DTOs.Token token = new();

        //Security Key Symmetric
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:IssuerSigningKey"]));

        //Create encrypted identity
        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        //Token settings
        token.Expiration = DateTime.UtcNow.AddHours(minute);

        JwtSecurityToken securityToken = new(
            audience: _configuration["JWT:ValidAudience"],
            issuer: _configuration["JWT:ValidIssuer"],
            expires: token.Expiration,
            signingCredentials: signingCredentials,
            claims: new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            });

        JwtSecurityTokenHandler tokenHandler = new();
        token.AccessToken = tokenHandler.WriteToken(securityToken);

        token.RefreshToken = CreateRefreshToken();

        return token;
    }

    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }
}