using StockApi.Application.Features.Stocks.Commands.CreateStock;
using StockApi.Application.Features.Stocks.Commands.UpdateStock;
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

        public static void MapFromCreateCommand(this Stock stock, CreateStockCommand request)
        {
            stock.Symbol = request.Symbol;
            stock.CompanyName = request.CompanyName;
            stock.Purchase = request.Purchase;
            stock.LastDiv = request.LastDiv;
            stock.Industry = request.Industry;
            stock.MarketCap = request.MarketCap;
        }
        
        public static void MapFromUpdateCommand(this Stock stock, UpdateStockCommand request)
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