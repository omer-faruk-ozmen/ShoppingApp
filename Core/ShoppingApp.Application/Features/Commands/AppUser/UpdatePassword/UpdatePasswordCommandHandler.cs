﻿using MediatR;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Exceptions;

namespace ShoppingApp.Application.Features.Commands.AppUser.UpdatePassword;

public class UpdatePasswordCommandHandler :IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
{
    private readonly IUserService _userService;

    public UpdatePasswordCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        if (!request.Password.Equals(request.PasswordConfirm))
            throw new PasswordChangeFailedException("Passwords do not match.");


        await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);

        return new ();
    }
}