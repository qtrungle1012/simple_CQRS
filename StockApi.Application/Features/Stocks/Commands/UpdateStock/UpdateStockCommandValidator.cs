using FluentValidation;

namespace StockApi.Application.Features.Stocks.Commands.UpdateStock
{
    public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
    {
        public UpdateStockCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Stock ID must be greater than 0.");

            RuleFor(x => x.Symbol)
                .MaximumLength(10)
                .WithMessage("Symbol max length is 10.")
                .When(x => !string.IsNullOrWhiteSpace(x.Symbol));

            RuleFor(x => x.CompanyName)
                .MaximumLength(100)
                .WithMessage("Company name max length is 100.")
                .When(x => !string.IsNullOrWhiteSpace(x.CompanyName));

            RuleFor(x => x.Purchase)
                .GreaterThan(0)
                .WithMessage("Purchase must be greater than 0.");

            RuleFor(x => x.LastDiv)
                .GreaterThanOrEqualTo(0)
                .WithMessage("LastDiv cannot be negative.");

            RuleFor(x => x.Industry)
                .MaximumLength(50)
                .WithMessage("Industry max length is 50.")
                .When(x => !string.IsNullOrWhiteSpace(x.Industry));

            RuleFor(x => x.MarketCap)
                .GreaterThanOrEqualTo(0)
                .WithMessage("MarketCap cannot be negative.");
        }
    }
}