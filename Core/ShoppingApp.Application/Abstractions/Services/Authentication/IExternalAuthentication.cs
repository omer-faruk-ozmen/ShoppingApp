namespace ShoppingApp.Application.Abstractions.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<DTOs.Token> GoogleLoginAsync(string idToken,string provider,int accessTokenLifeTime);
    }
}
