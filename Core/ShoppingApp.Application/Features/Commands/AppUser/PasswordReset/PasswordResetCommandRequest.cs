﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ShoppingApp.Application.Features.Commands.AppUser.PasswordReset
{
    public class PasswordResetCommandRequest :IRequest<PasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}
