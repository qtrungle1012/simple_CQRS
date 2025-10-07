using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Stocks.Queries.GetStockById
{
    public class GetStockByIdQueryHandler
    {
        private readonly IStockRepository _stockRepository;
        public GetStockByIdQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        //handel
    }
}