using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Stocks.Queries.GetStocks
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, List<StockDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public GetStockQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<List<StockDto>> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _stockRepository.GetAllAsync();
            return _mapper.Map<List<StockDto>>(stocks);
            // return stocks.Select(s => s.toStockDto()).ToList(); cach chua su dung AutoMapper
        }
    }
}