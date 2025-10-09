using StockApi.Application.Features.Stocks.Commands.CreateStock;
using StockApi.Application.Features.Stocks.Commands.UpdateStock;
using StockApi.Domain.Entities;

namespace StockApi.Application.Common.Mappings
{
    public static class StockMapper
    {
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