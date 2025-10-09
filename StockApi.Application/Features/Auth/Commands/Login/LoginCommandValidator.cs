using FluentValidation;

namespace StockApi.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Username)
               .NotEmpty().WithMessage("Username is required");
               
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password is required");
              
        }
    }
}