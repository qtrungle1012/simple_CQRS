using MediatR;
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

        public LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }
        public async Task<TokenResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid username or password");

            // So khớp password (nếu hashed)
            if (!_passwordHasher.VerifyPassword(user.Password, request.Password))
                throw new UnauthorizedAccessException("Invalid username or password");

            return _jwtService.GenerateToken(user);
        }
    }
}