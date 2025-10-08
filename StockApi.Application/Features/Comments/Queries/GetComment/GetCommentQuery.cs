using MediatR;
using StockApi.Application.Features.Comments.DTOs;

namespace StockApi.Application.Features.Comments.Queries.GetComment
{
    public class GetCommentQuery : IRequest<List<CommentDto>>
    {
        
    }
}