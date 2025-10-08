using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StockApi.Application.Features.Comments.DTOs;

namespace StockApi.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<CommentDto>
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}