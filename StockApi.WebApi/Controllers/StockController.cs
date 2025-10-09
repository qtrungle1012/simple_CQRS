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
            var response = new ApiResponse<List<StockDto>>(1000, stocks);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock = await _mediator.Send(new GetStockByIdQuery() { Id = id });
            var response = new ApiResponse<StockDto>(1000, stock);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStockCommand() { Id = id });
            var response = new ApiResponse<int>(1000, result);
            return Ok(response);
        }

       [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockCommand createStockCommand)
        {
            try
            {
                var createdStock = await _mediator.Send(createStockCommand);
                var res = new ApiResponse<StockDto>(1000, createdStock);
                return Ok(res);
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { code = 400, message = "Validation failed", errors });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStockCommand updateStockCommand)
        {
            try
            {
                if (id != updateStockCommand.Id)
                {
                    updateStockCommand.Id = id;
                }
                var update = await _mediator.Send(updateStockCommand);
                var res = new ApiResponse<StockDto>(1000, update);
                return Ok(res);
            }
            catch (FluentValidation.ValidationException ex)
            {
                
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { code = 400, message = "Validation failed", errors });
            }
        }
      

    }
}