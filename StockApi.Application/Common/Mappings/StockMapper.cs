using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Domain.Entities;

namespace StockApi.Application.Common.Mappings
{
    public static class StockMapper
    {
        public static StockDto toStockDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap,
                Comments = stock.Comments.Select(c => c.toCommentDto()).ToList()
            };
        }

        public static Stock toStockFromCreateDto(this CreateStockRequest request)
        {
            return new Stock
            {
                Symbol = request.Symbol,
                CompanyName = request.CompanyName,
                Purchase = request.Purchase,
                LastDiv = request.LastDiv,
                Industry = request.Industry,
                MarketCap = request.MarketCap
            };
        }
        public static void UpdateStockFromDto(this Stock stock, UpdateStockRequest request)
        {
            stock.Symbol = request.Symbol;
            stock.CompanyName = request.CompanyName;
            stock.Purchase = request.Purchase;
            stock.LastDiv = request.LastDiv;
            stock.Industry = request.Industry;
            stock.MarketCap = request.MarketCap;
        }


    }
}