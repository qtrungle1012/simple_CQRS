
namespace StockApi.Application.Features.Auth.DTOs
{
    public class TokenResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}