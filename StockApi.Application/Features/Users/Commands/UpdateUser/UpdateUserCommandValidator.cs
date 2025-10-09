using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace StockApi.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            // Bắt buộc có ID để update
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("User ID must be greater than 0.");

            // FullName không bắt buộc, nhưng nếu có thì không được quá dài
            RuleFor(x => x.FullName)
                .MaximumLength(100)
                .WithMessage("Full name cannot exceed 100 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.FullName));

            // Email không bắt buộc, nhưng nếu có thì phải đúng định dạng
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            // Password không bắt buộc, nhưng nếu có thì phải đủ mạnh
            RuleFor(x => x.Password)
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.")
                .When(x => !string.IsNullOrWhiteSpace(x.Password));
        }
    }
}