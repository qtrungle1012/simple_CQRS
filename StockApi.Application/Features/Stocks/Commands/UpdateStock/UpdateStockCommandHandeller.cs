using AutoMapper;
using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Stocks.Commands.UpdateStock
{
    public class UpdateStockCommandHandeller : IRequestHandler<UpdateStockCommand, StockDto>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public UpdateStockCommandHandeller(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<StockDto> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepository.GetByIdAsync(request.Id);
            stock?.MapFromUpdateCommand(request);
            await _stockRepository.UpdateAsync(stock!.Id, stock);
            var stockDto = _mapper.Map<StockDto>(stock);
            return stockDto;
        }
    }
}