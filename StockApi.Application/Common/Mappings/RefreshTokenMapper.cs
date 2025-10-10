using StockApi.Application.Features.Auth.DTOs;
using StockApi.Domain.Entities;

namespace StockApi.Application.Common.Mappings
{
    public static class RefreshTokenMapper
    {
        public static void MapFromUserAndTokenResponse(
            this RefreshToken entity,
            User user,
            TokenResponse tokenResponse)
        {
            entity.UserId = user.Id;
            entity.Token = tokenResponse.RefreshToken;
            entity.Expires = tokenResponse.RefreshTokenExpiration;
            entity.IsUsed = false;
            entity.IsRevoked = false;
        }
    }
}