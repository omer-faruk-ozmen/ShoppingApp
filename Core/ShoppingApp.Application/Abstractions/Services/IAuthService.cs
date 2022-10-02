using ShoppingApp.Application.Abstractions.Services.Authentication;

namespace ShoppingApp.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {
        Task PasswordResetAsync(string userEmail);
        Task<bool> VerifyResetTokenAsync(string userId, string resetToken);
    }
}
