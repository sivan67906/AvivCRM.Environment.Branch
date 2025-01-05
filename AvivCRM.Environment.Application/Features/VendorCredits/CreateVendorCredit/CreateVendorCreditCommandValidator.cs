using AvivCRM.Environment.Application.DTOs.VendorCredit;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.VendorCredits.CreateVendorCredit;
public class CreateVendorCreditCommandValidator : AbstractValidator<CreateVendorCreditRequest>
{
    public CreateVendorCreditCommandValidator()
    {
        RuleFor(x => x.Prefix)
                    .NotEmpty().WithMessage("Prefix not empty")
                    .MaximumLength(25).WithMessage("Prefix must not exceed 25 Characters")
                    .MinimumLength(1).WithMessage("Prefix should not be less than 3 characters");
        RuleFor(x => x.Seperater)
                    .NotEmpty().WithMessage("Seperater not empty")
                    .MaximumLength(25).WithMessage("Seperater must not exceed 25 Characters")
                    .MinimumLength(1).WithMessage("Seperater should not be less than 3 characters");
        RuleFor(x => x.NumberDigits)
                    .NotEmpty().WithMessage("NumberDigits not empty")
                    .MaximumLength(25).WithMessage("NumberDigits must not exceed 25 Characters")
                    .MinimumLength(1).WithMessage("NumberDigits should not be less than 3 characters");

    }
}
