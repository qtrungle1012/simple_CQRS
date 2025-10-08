using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StockApi.Application.Common.Mappings;
using StockApi.Application.Features.Comments.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentDto>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            comment?.MapFromUpdateCommand(request);
            await _commentRepository.UpdateAsync(comment!.Id, comment);
            return _mapper.Map<CommentDto>(comment);
        }
    }
}