using MediatR;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public LogoutCommandHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var token = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);
            if (token == null)
            {
                throw new UnauthorizedAccessException("Invalid refresh token");
            }
            await _refreshTokenRepository.InvalidateAsync(token);

            return true;
        }
    }
}