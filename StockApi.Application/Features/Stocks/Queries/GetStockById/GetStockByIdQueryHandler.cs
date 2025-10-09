using AutoMapper;
using MediatR;
using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Stocks.Queries.GetStockById
{
    public class GetStockByIdQueryHandler : IRequestHandler<GetStockByIdQuery, StockDto>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public GetStockByIdQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<StockDto> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<StockDto>(await _stockRepository.GetByIdAsync(request.Id));
        }

        //handle
    }
}