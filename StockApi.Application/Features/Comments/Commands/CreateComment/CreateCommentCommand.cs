using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StockApi.Application.Features.Comments.DTOs;

namespace StockApi.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CommentDto>
    {
    
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; 
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
        public int? UserId { get; set; }
    }
}