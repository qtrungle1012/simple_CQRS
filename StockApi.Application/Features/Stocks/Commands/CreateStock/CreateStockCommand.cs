using MediatR;
using StockApi.Application.Features.Stocks.DTOs;

namespace StockApi.Application.Features.Stocks.Commands.CreateStock
{
    public class CreateStockCommand : IRequest<StockDto>
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}