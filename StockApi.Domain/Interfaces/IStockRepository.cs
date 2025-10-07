using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApi.Domain.Entities;

namespace StockApi.Domain.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<int> UpdateAsync(int id, Stock stock);
        Task<int> DeleteAsync(int id);

    }
}