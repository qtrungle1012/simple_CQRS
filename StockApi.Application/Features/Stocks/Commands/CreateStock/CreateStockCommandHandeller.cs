using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Domain.Entities;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Stocks.Commands.CreateStock
{
    public class CreateStockCommandHandeller : IRequestHandler<CreateStockCommand, StockDto>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public CreateStockCommandHandeller(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<StockDto> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = new Stock();
            stock.MapFromCreateCommand(request);

            var created = await _stockRepository.CreateAsync(stock);
            return _mapper.Map<StockDto>(created);
        }
    }
}