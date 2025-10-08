using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.Application.Features.Comments.Commands.CreateComment;
using StockApi.Application.Features.Comments.Commands.UpdateComment;
using StockApi.Application.Features.Comments.DTOs;
using StockApi.Application.Features.Comments.Queries.GetComment;
using StockApi.Application.Features.Comments.Queries.GetCommentById;
using StockApi.WebApi.Contracts.Common;

namespace StockApi.WebApi.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _mediator.Send(new GetCommentQuery());
            var response = new ApiResponse<List<CommentDto>>(1000, comments);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery() { Id = id });
            var response = new ApiResponse<CommentDto>(1000, comment);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentCommand createCommentCommand)
        {
            try
            {
                var createdComment = await _mediator.Send(createCommentCommand);
                var res = new ApiResponse<CommentDto>(1000, createdComment);
                return Ok(res);
            }
            catch (FluentValidation.ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { code = 400, message = "Validation failed", errors });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentCommand updateCommentCommand)
        {
            try
            {
                var update = await _mediator.Send(updateCommentCommand);
                var res = new ApiResponse<CommentDto>(1000, update);
                return Ok(res);
            }
            catch (FluentValidation.ValidationException ex)
            {
                
                var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return BadRequest(new { code = 400, message = "Validation failed", errors });
            }
        }

    }
}