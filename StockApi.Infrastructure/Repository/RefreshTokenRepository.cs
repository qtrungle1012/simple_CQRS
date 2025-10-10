using Microsoft.EntityFrameworkCore;
using StockApi.Domain.Entities;
using StockApi.Domain.Interfaces;
using StockApi.Infrastructure.Data;

namespace StockApi.Infrastructure.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RefreshToken> CreateRefreshToken(RefreshToken refreshToken)
        {
            await _context.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
            return refreshToken;
        }

        public async Task DeleteExpiredTokensAsync()
        {
            var expiredTokens = await _context.RefreshTokens.Where(x => x.Expires < DateTime.UtcNow).ToListAsync();
            _context.RefreshTokens.RemoveRange(expiredTokens);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token);
        }

        public async  Task InvalidateAsync(RefreshToken refreshToken)
        {
            refreshToken.IsRevoked = true;
            _context.RefreshTokens.Update(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task RevokeAllUserTokensAsync(int userId)
        {
            var userTokens = await _context.RefreshTokens.Where(x => x.UserId == userId && !x.IsRevoked).ToListAsync();
            foreach (var token in userTokens)
            {
                token.IsRevoked = true;
            }

            await _context.SaveChangesAsync();

        }

        // public async  Task SaveChangesAsync()
        // {
        //     await _context.SaveChangesAsync();
        // }
    }
}