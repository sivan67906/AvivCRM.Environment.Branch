#region

using AvivCRM.Environment.Application.DTOs.Currencies;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.Command.CreateCurrency;
public class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyRequest>
{
    public CreateCurrencyCommandValidator()
    {
        RuleFor(x => x.CurrencyName)
            .NotEmpty().WithMessage("Currency Name not empty")
            .MaximumLength(25).WithMessage("Currency Name must not exceed 25 Characters")
            .MinimumLength(2).WithMessage("Currency Name should not be less than 3 characters");
        RuleFor(x => x.CurrencySymbol)
            .NotEmpty().WithMessage("Currency Symbol not empty")
            .MaximumLength(5).WithMessage("Currency Symbol must not exceed 25 Characters")
            .MinimumLength(1).WithMessage("Currency Symbol should not be less than 3 characters");
        RuleFor(x => x.CurrencyCode)
            .NotEmpty().WithMessage("Currency Code not empty")
            .MaximumLength(25).WithMessage("Currency Code must not exceed 25 Characters")
            .MinimumLength(1).WithMessage("Currency Code should not be less than 3 characters");


        //RuleFor(x => x.CurrencyPosition)
        //    .NotEmpty().WithMessage("Currency Position not empty")
        //    .MaximumLength(25).WithMessage("Currency Position must not exceed 25 Characters")
        //    .MinimumLength(1).WithMessage("Currency Position should not be less than 3 characters");
        //RuleFor(x => x.ThousandSeparator)
        //    .NotEmpty().WithMessage("Thousand Separator not empty")
        //    .MaximumLength(25).WithMessage("Thousand Separator must not exceed 25 Characters")
        //    .MinimumLength(1).WithMessage("Thousand Separator should not be less than 3 characters");
        //RuleFor(x => x.DecimalSeparator)
        //    .NotEmpty().WithMessage("Decimal Separator not empty")
        //    .MaximumLength(25).WithMessage("Decimal Separator must not exceed 25 Characters")
        //    .MinimumLength(1).WithMessage("Decimal Separator should not be less than 3 characters");
        //RuleFor(x => x.NumberofDecimals)
        //    .NotEmpty().WithMessage("Number of Decimals not empty");
    }
}