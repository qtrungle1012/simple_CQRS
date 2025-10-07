using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Application.Features.Stocks.Queries.GetStocks;
using StockApi.WebApi.Contracts.Common;

namespace StockApi.WebApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _mediator.Send(new GetStockQuery());
            var response = new ApiResponse<List<StockDto>>(1000, stocks);
            return Ok(response);
        }

    }
}