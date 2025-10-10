
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StockApi.Application.Features.Auth.DTOs;
using StockApi.Application.Interfaces;
using StockApi.Domain.Entities;
using StockApi.Infrastructure.Security;

namespace StockApi.Infrastructure.Service
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }


        public TokenResponse GenerateToken(User user)
        {
            // Tạo access token
            var accessToken = GenerateAccessToken(user);

            // Tạo refresh token
            var refreshToken = GenerateRefreshToken();

            // Trả về response
            return new TokenResponse
            {
                AccessToken = accessToken.Token,
                AccessTokenExpiration = accessToken.Expiration,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.Expiration
            };
        }

        private (string Token, DateTime Expiration) GenerateAccessToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return (
                tokenHandler.WriteToken(token),
                tokenDescriptor.Expires!.Value
            );
        }

        private (string Token, DateTime Expiration) GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            string token = Convert.ToBase64String(randomNumber);
            DateTime expiration = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays);

            return (token, expiration);
        }
    }
}