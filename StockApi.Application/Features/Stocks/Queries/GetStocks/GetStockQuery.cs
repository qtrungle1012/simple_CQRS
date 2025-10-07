using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StockApi.Application.Features.Stocks.DTOs;

namespace StockApi.Application.Features.Stocks.Queries.GetStocks
{
    public class GetStockQuery : IRequest<List<StockDto>>
    {

    }
}