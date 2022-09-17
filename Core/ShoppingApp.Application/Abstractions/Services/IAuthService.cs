using ShoppingApp.Application.Abstractions.Services.Authentication;

namespace ShoppingApp.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {

    }
}
