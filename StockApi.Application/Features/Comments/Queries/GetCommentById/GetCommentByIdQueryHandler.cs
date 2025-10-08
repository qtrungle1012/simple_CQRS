using AutoMapper;
using MediatR;
using StockApi.Application.Features.Comments.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetCommentByIdQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var commentDetail = await _commentRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CommentDto>(commentDetail);
        }
    }
}