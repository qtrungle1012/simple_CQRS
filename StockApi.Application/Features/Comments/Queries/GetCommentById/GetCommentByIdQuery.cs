using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StockApi.Application.Features.Comments.DTOs;

namespace StockApi.Application.Features.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQuery : IRequest<CommentDto>
    {
        public int Id { get; set; }

    }
}