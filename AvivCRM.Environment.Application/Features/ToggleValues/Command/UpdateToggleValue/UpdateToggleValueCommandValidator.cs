using AvivCRM.Environment.Application.DTOs.ToggleValues;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.ToggleValues.Command.UpdateToggleValue;

public class UpdateToggleValueCommandValidator : AbstractValidator<UpdateToggleValueRequest>
{
    public UpdateToggleValueCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Source Id should not be empty");

        //RuleFor(x => x.Name)
        //            .NotEmpty().WithMessage("Toggle Value Name should not be empty")
        //            .MaximumLength(25).WithMessage("Toggle Value Name must not exceed 25 Characters")
        //            .MinimumLength(3).WithMessage("Toggle Value Name should not be less than 3 characters");

    }
}










































