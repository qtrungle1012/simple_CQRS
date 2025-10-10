using MediatR;
using StockApi.Application.Features.Auth.DTOs;

namespace StockApi.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<TokenResponse>
    {
         public string Token { get; set; } = string.Empty;
    }
}