using MediatR;
using StockApi.Application.Features.Auth.DTOs;

namespace StockApi.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponse>
    {

        public Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}