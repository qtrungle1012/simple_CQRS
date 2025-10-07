using Microsoft.EntityFrameworkCore;
using StockApi.Domain.Entities;
using StockApi.Domain.Interfaces;
using StockApi.Infrastructure.Data;

namespace StockApi.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context) => _context = context;
        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Stocks
                 .Where(model => model.Id == id)
                 .ExecuteDeleteAsync();
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Stock stock)
        {
            return await _context.Stocks
                 .Where(model => model.Id == id)
                 .ExecuteUpdateAsync(setters => setters
                   .SetProperty(m => m.Id, stock.Id)
                   .SetProperty(m => m.MarketCap, stock.MarketCap)
                   .SetProperty(m => m.Purchase, stock.Purchase)
                   .SetProperty(m => m.CompanyName, stock.CompanyName)
                   .SetProperty(m => m.Symbol, stock.Symbol)
                   .SetProperty(m => m.LastDiv, stock.LastDiv)
                 );
        }

    }
}
