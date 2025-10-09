using StockApi.Application.Common.Mappings;
using StockApi.Domain.Entities;

namespace StockApi.Application.Features.Users.DTOs
{
    public class UserDto: IMapFrom<User>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}