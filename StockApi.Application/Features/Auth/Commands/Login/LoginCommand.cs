using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StockApi.Application.Features.Auth.DTOs;

namespace StockApi.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<TokenResponse>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}