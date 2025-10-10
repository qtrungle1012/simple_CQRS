using StockApi.Domain.Entities;

namespace StockApi.Domain.Interfaces
{
    public interface  IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task<RefreshToken> CreateRefreshToken(RefreshToken refreshToken);
        Task InvalidateAsync(RefreshToken refreshToken);
        Task RevokeAllUserTokensAsync(int userId);
        Task DeleteExpiredTokensAsync();

        // Task SaveChangesAsync();
    }
}