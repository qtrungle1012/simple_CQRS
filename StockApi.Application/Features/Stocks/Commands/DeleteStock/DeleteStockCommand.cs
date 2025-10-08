using MediatR;

namespace StockApi.Application.Features.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}