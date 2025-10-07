using MediatR;
using StockApi.Application.Features.Stocks.DTOs;

namespace StockApi.Application.Features.Stocks.Queries.GetStockById
{
    public class GetStockByIdQuery : IRequest<StockDto>
    {

    }
}