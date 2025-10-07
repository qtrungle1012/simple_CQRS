using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApi.Domain.Entities;

namespace StockApi.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<int> UpdateAsync(int id, Comment comment);
        Task<int> DeleteAsync(int id);
    }
}