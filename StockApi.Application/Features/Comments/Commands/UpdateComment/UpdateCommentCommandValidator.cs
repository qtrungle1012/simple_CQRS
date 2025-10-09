using FluentValidation;

namespace StockApi.Application.Features.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
         public UpdateCommentCommandValidator()
         {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters")
                .When(x => x.Title != null);

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters")
                .When(x => x.Content != null);
         }

    }
}