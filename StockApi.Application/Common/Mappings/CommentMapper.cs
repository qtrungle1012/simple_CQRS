using StockApi.Application.Features.Comments.DTOs;
using StockApi.Domain.Entities;

namespace StockApi.Application.Common.Mappings
{
    public static class CommentMapper
    {
        public static CommentDto toCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                Title = comment.Title,
                CreateOn = comment.CreateOn,
                StockId = comment.StockId,
            };
        }

        public static Comment toCommentFromCreate(this CreateCommentRequest request, int stockId)
        {
            return new Comment
            {
                Content = request.Content,
                Title = request.Title,
                StockId = stockId,
            };
        }

        public static void toCommentFromUpdate(this Comment comment, UpdateCommentRequest request)
        {
            comment.Title = request.Title;
            comment.Content = request.Content;
        }
    }
}