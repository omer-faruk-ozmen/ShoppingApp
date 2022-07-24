using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Application.Abstractions.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<DTOs.Token> GoogleLoginAsync(string idToken,string provider,int accessTokenLifeTime);
    }
}
