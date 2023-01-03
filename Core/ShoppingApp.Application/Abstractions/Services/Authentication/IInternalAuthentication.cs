﻿namespace ShoppingApp.Application.Abstractions.Services.Authentication;

public interface IInternalAuthentication
{
    Task<DTOs.Token> LoginAsync(string userNameOrEmail,string password,int accessTokenLifeTime);
    Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
}