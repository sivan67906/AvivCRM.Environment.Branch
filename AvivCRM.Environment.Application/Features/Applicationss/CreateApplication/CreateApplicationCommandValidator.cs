using AvivCRM.Environment.Application.DTOs.Applications;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Applicationss.CreateApplication;
public class CreateApplicationCommandValidator : AbstractValidator<CreateApplicationRequest>
{
    public CreateApplicationCommandValidator()
    {

        //RuleFor(x => x.)
        //            .NotEmpty().WithMessage("Contract Prefix not empty")
        //            .MaximumLength(25).WithMessage("Contract Prefix must not exceed 25 Characters")
        //            .MinimumLength(3).WithMessage("Contract Prefix should not be less than 3 characters");
        //RuleFor(x => x.ContractNumberDigits)
        //            .NotEmpty().WithMessage("Contract Prefix not empty");

        //RuleFor(x => x.ContractNumberSeprator)
        //            .NotEmpty().WithMessage("Contract Prefix not empty")
        //            .MaximumLength(25).WithMessage("Contract Prefix must not exceed 25 Characters")
        //            .MinimumLength(1).WithMessage("Contract Prefix should not be less than 3 characters");
    }
}
