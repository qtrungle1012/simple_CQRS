using Microsoft.EntityFrameworkCore;
using StockApi.Domain.Entities;
using StockApi.Domain.Interfaces;
using StockApi.Infrastructure.Data;

namespace StockApi.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;
        public async Task<User> CreateAsync(User entity)
        {
            await _context.User.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.User.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<int> UpdateAsync(int id, User entity)
        {
            return await _context.User.Where(u => u.Id == id)
            .ExecuteUpdateAsync( setters => setters
                            .SetProperty(m => m.Email, entity.Email)
                            .SetProperty(m => m.Password, entity.Password)           
            );
        }
    }
}