using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.Application.Features.Stocks.Commands.CreateStock;
using StockApi.Application.Features.Stocks.Commands.DeleteStock;
using StockApi.Application.Features.Stocks.Commands.UpdateStock;
using StockApi.Application.Features.Stocks.DTOs;
using StockApi.Application.Features.Stocks.Queries.GetStockById;
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
            var response = new ApiResponse<List<StockDto>>((int) ErrorCode.SUCCESS, stocks);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _mediator.Send(new GetStockByIdQuery() { Id = id });
            var response = new ApiResponse<StockDto>((int) ErrorCode.SUCCESS, stock);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStockCommand() { Id = id });
            var response = new ApiResponse<int>((int) ErrorCode.SUCCESS, result);
            return Ok(response);
        }

       [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockCommand createStockCommand)
        {
          
            var createdStock = await _mediator.Send(createStockCommand);
            var res = new ApiResponse<StockDto>((int) ErrorCode.SUCCESS, createdStock);
            return Ok(res);
           
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStockCommand updateStockCommand)
        {
            if (id != updateStockCommand.Id)
            {
                updateStockCommand.Id = id;
            }
            var update = await _mediator.Send(updateStockCommand);
            var res = new ApiResponse<StockDto>((int) ErrorCode.SUCCESS, update);
            return Ok(res);
        }
      

    }
}