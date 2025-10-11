using MediatR;
using StockApi.Application.Features.Auth.DTOs;

namespace StockApi.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<TokenResponse>
    {
         public string RefreshToken { get; set; } = string.Empty;
    }
}