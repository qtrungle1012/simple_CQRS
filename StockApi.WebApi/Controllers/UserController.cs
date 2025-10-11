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
            var response = new ApiResponse<List<UserDto>>((int)ErrorCode.SUCCESS, users);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            var response = new ApiResponse<UserDto>((int)ErrorCode.SUCCESS, user);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand() { Id = id });
            var response = new ApiResponse<int>((int) ErrorCode.SUCCESS, result);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
           
            var createUser = await _mediator.Send(request);
            var res = new ApiResponse<UserDto>((int) ErrorCode.SUCCESS, createUser);
            return Ok(res);
           
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand request)
        {
            if (id != request.Id)
            {
                request.Id = id;
            }
            var updateUser = await _mediator.Send(request);
            var res = new ApiResponse<UserDto>((int) ErrorCode.SUCCESS, updateUser);
            return Ok(res);
        }

    }
}