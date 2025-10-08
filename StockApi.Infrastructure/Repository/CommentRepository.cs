using Microsoft.EntityFrameworkCore;
using StockApi.Domain.Entities;
using StockApi.Domain.Interfaces;
using StockApi.Infrastructure.Data;

namespace StockApi.Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context) => _context = context;

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Comments
                            .Where(m => m.Id == id)
                            .ExecuteDeleteAsync();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Comment comment)
        {
            return await _context.Comments
                            .Where(m => m.Id == id)
                            .ExecuteUpdateAsync(setter => setter
                              .SetProperty(m => m.Title, comment.Title)
                              .SetProperty(m => m.Content, comment.Content));
        }
    }
}