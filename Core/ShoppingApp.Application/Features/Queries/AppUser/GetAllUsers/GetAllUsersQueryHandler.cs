﻿using MediatR;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.DTOs.User;

namespace ShoppingApp.Application.Features.Queries.AppUser.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        List<ListUserDto> users = await _userService.GetAllUsersAsync(request.Page, request.Size);

        return new()
        {
            Users = users,
            TotalUsersCount = _userService.TotalUsersCount
        };
    }
}