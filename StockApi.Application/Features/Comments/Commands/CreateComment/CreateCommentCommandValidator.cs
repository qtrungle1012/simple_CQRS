
using FluentValidation;

namespace StockApi.Application.Features.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters");

            RuleFor(x => x.CreateOn)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("CreateOn cannot be in the future");

            RuleFor(x => x.StockId)
                .NotNull().WithMessage("StockId is required")
                .GreaterThan(0).WithMessage("StockId must be greater than 0");

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("UserId is required")
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}