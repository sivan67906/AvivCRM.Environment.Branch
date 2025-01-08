#region

using AvivCRM.Environment.Application.DTOs.Contracts;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.UpdateContract;
public class UpdateContractCommandValidator : AbstractValidator<UpdateContractRequest>
{
    public UpdateContractCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Contract Id should not be empty");

        RuleFor(x => x.ContractPrefix)
            .NotEmpty().WithMessage("Contract Prefix not empty")
            .MaximumLength(25).WithMessage("Contract Prefix must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Contract Prefix should not be less than 3 characters");
        RuleFor(x => x.ContractNumberDigits)
            .NotEmpty().WithMessage("Contract Prefix not empty");

        RuleFor(x => x.ContractNumberSeprator)
            .NotEmpty().WithMessage("Contract Prefix not empty")
            .MaximumLength(25).WithMessage("Contract Prefix must not exceed 25 Characters")
            .MinimumLength(1).WithMessage("Contract Prefix should not be less than 3 characters");
    }
}