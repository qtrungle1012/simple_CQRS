using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApi.Application.Features.Users.Commands.CreateUser;
using StockApi.Application.Features.Users.Commands.DeleteUser;
using StockApi.Application.Features.Users.Commands.UpdateUser;
using StockApi.Application.Features.Users.DTOs;
using StockApi.Application.Features.Users.Queries.GetUser;
using StockApi.Application.Features.Users.Queries.GetUserById;
using StockApi.WebApi.Contracts.Common;

namespace StockApi.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetUserQuery());
            var response = new ApiResponse<List<UserDto>>(1000, users);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            var response = new ApiResponse<UserDto>(1000, user);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand() { Id = id });
            var response = new ApiResponse<int>(1000, result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
            try
            {
                var createUser = await _mediator.Send(request);
                var res = new ApiResponse<UserDto>(1000, createUser);
                return Ok(res);
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { code = 400, message = "Validation failed", errors });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand request)
        {
            try
            {
                if (id != request.Id)
                {
                    request.Id = id;
                }
                var updateUser = await _mediator.Send(request);
                var res = new ApiResponse<UserDto>(1000, updateUser);
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