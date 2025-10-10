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
            try
            {
                var tokenResponse = await _mediator.Send(request);
                var response = new ApiResponse<TokenResponse>(1000, tokenResponse);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand request)
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

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            try
            {
                var tokenRefresh = await _mediator.Send(command);
                var res = new ApiResponse<TokenResponse>(1000, tokenRefresh);
                return Ok(res);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
        {
            try
            {
                await _mediator.Send(command);
                var res = new ApiResponse<string>(1000, "Đăng xuất thành công");
                return Ok(res);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}