
using MediatR;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, int>
    {
        private readonly IStockRepository _stockRepository;

        public DeleteStockCommandHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<int> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepository.GetByIdAsync(request.Id);
            if (stock == null) return 0;
            return await _stockRepository.DeleteAsync(stock.Id);
        }
    }
}