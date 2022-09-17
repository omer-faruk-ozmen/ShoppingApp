using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute, AppUser appUser);
        string CreateRefreshToken();
    }
}
