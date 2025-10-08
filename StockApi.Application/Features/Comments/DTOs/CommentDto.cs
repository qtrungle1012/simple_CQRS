using StockApi.Application.Common.Mappings;
using StockApi.Domain.Entities;

namespace StockApi.Application.Features.Comments.DTOs
{
    public class CommentDto : IMapFrom<Comment>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
    }
}