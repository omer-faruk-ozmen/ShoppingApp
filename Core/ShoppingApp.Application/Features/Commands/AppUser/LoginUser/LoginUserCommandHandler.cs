﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShoppingApp.Application.Exceptions;
using U= ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler:IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
    {
        readonly UserManager<U.AppUser> _userManager;
        readonly SignInManager<U.AppUser> _signInManager;

        public LoginUserCommandHandler(UserManager<U.AppUser> userManager, SignInManager<U.AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            U.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user == null)
                throw new NotFoundUserException();


            SignInResult result= await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);

            if (result.Succeeded) //Authentication success
            {
                //Authorization

            }

            return new();

        }
    }
}
