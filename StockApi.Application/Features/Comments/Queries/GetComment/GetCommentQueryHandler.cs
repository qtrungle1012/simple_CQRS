
using AutoMapper;
using MediatR;
using StockApi.Application.Features.Comments.DTOs;
using StockApi.Domain.Interfaces;

namespace StockApi.Application.Features.Comments.Queries.GetComment
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
         private readonly IMapper _mapper;
        public GetCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllAsync();
            return _mapper.Map<List<CommentDto>>(comments);
        }
    }
}