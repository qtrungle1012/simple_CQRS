using System.Net;
using System.Text.Json;
using StockApi.Application.Common.Exceptions;
using StockApi.WebApi.Contracts.Common;

namespace StockApi.WebApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            ApiResponse<object> errorResponse;

            int statusCode;

            switch (exception)
            {
                case AppValidationException appEx:
                    statusCode = (int)HttpStatusCode.BadRequest;

                    errorResponse = new ApiResponse<object>(
                        (int)ErrorCode.VALIDATION_ERROR,
                        appEx.Message,
                        appEx.Errors
                    );
                    break;


                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    errorResponse = new ApiResponse<object>((int)ErrorCode.NOT_FOUND, exception.Message);
                    break;

                case BusinessException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse = new ApiResponse<object>((int)ErrorCode.BUSINESS_ERROR, exception.Message);
                    break;

                // case UnauthorizedException:
                //     statusCode = (int)HttpStatusCode.Unauthorized;
                //     errorResponse = new ErrorResponse((int)ErrorCode.UNAUTHORIZED, exception.Message);
                //     break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse = new ApiResponse<object>((int)ErrorCode.INTERNAL_SERVER_ERROR, exception.Message);
                    break;
            }

            context.Response.StatusCode = statusCode;
            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }

    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    
    }
}