using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Stocks.Queries.GetStocks
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, List<StockDto>>
    {
        private readonly IStockRepository _stockRepository;
        public GetStockQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<List<StockDto>> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _stockRepository.GetAllAsync();
            return stocks.Select(s => s.toStockDto()).ToList();
        }
    }
}