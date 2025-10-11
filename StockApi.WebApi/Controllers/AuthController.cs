using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApi.Application.Features.Auth.Commands.Login;
using StockApi.Application.Features.Auth.Commands.Logout;
using StockApi.Application.Features.Auth.Commands.RefreshToken;
using StockApi.Application.Features.Auth.DTOs;
using StockApi.Application.Features.Users.Commands.CreateUser;
using StockApi.Application.Features.Users.DTOs;
using StockApi.WebApi.Contracts.Common;

namespace StockApi.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
           
                var tokenResponse = await _mediator.Send(request);
                var response = new ApiResponse<TokenResponse>((int)ErrorCode.SUCCESS, tokenResponse);
                return Ok(response);
           
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand request)
        {
           
            var createUser = await _mediator.Send(request);
            var res = new ApiResponse<UserDto>((int) ErrorCode.SUCCESS, createUser);
            return Ok(res);
           
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
           
            var tokenRefresh = await _mediator.Send(command);
            var res = new ApiResponse<TokenResponse>((int) ErrorCode.SUCCESS, tokenRefresh);
            return Ok(res);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
        {
           
            await _mediator.Send(command);
            var res = new ApiResponse<string>((int)ErrorCode.SUCCESS, "Đăng xuất thành công");
            return Ok(res);
            
        }
    }
}