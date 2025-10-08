using FluentValidation;

namespace StockApi.Application.Features.Stocks.Commands.UpdateStock
{
    public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
    {
        public UpdateStockCommandValidator()
        {
            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Symbol is required")
                .MaximumLength(10).WithMessage("Symbol max length is 10");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company name is required")
                .MaximumLength(100).WithMessage("Company name max length is 100");

            RuleFor(x => x.Purchase)
                .GreaterThan(0).WithMessage("Purchase must be greater than 0");

            RuleFor(x => x.LastDiv)
                .GreaterThanOrEqualTo(0).WithMessage("LastDiv cannot be negative");

            RuleFor(x => x.Industry)
                .NotEmpty().WithMessage("Industry is required");

            RuleFor(x => x.MarketCap)
                .GreaterThanOrEqualTo(0).WithMessage("MarketCap cannot be negative");
        }
    }
}