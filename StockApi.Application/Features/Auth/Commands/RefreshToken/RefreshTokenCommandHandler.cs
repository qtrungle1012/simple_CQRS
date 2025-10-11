using MediatR;
using StockApi.Application.Common.Exceptions;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Auth.DTOs;
using StockApi.Application.Interfaces;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponse>
    {
        private readonly IJwtService _jwtService;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenCommandHandler(
            IJwtService jwtService,
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);
            if (refreshToken == null || refreshToken.IsRevoked || refreshToken.Expires < DateTime.UtcNow)
                throw new BusinessException("Refresh token invalid or expired");

            var user = await _userRepository.GetByIdAsync(refreshToken.UserId);
            if (user == null)
                throw new BusinessException("User not found");

            var newAccessToken = _jwtService.GenerateToken(user);
             var refreshTokenEntity = new Domain.Entities.RefreshToken();
            refreshTokenEntity.MapFromUserAndTokenResponse(user, newAccessToken);

            await _refreshTokenRepository.CreateRefreshToken(refreshTokenEntity);

            return newAccessToken;
        }
        
    }
}