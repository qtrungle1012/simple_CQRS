using StockApi.Application.Features.Comments.Commands.CreateComment;
using StockApi.Application.Features.Comments.Commands.UpdateComment;
using StockApi.Domain.Entities;

namespace StockApi.Application.Common.Mappings
{
    public static class CommentMapper
    {
       

        public static void MapFromCreateCommand(this Comment comment, CreateCommentCommand request)
        {
            comment.Content = request.Content;
            comment.Title = request.Title;
            comment.StockId = request.StockId;
            comment.UserId = request.UserId;
        }

        public static void MapFromUpdateCommand(this Comment comment, UpdateCommentCommand request)
        {
            comment.Title = request.Title;
            comment.Content = request.Content;
        }
    }
}