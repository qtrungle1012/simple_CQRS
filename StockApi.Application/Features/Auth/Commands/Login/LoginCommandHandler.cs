using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Auth.DTOs;
using StockApi.Application.Interfaces;
using StockApi.Application.Interfaces.Security;
using StockApi.Domain.Interfaces;


namespace StockApi.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, TokenResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRefreshTokenRepository _refreshTokenRepository;


        public LoginCommandHandler(IUserRepository userRepository,
                                    IJwtService jwtService,
                                    IPasswordHasher passwordHasher,
                                    IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password");

            if (!_passwordHasher.VerifyPassword(user.Password, request.Password))
                throw new UnauthorizedAccessException("Invalid username or password");
            
            await _refreshTokenRepository.RevokeAllUserTokensAsync(user.Id);

            var tokenResponse = _jwtService.GenerateToken(user);

            var refreshTokenEntity = new Domain.Entities.RefreshToken();
            refreshTokenEntity.MapFromUserAndTokenResponse(user, tokenResponse);

            await _refreshTokenRepository.CreateRefreshToken(refreshTokenEntity);

            return tokenResponse;
        }
    }
}