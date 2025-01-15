using AvivCRM.Environment.Application.DTOs.ToggleValues;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.ToggleValues.Command.CreateToggleValue;

public class CreateToggleValueCommandValidator : AbstractValidator<CreateToggleValueRequest>
{
    public CreateToggleValueCommandValidator()
    {
        //RuleFor(x => x.Name)
        //    .NotEmpty().WithMessage("Toggle Value Name not empty")
        //    .MaximumLength(25).WithMessage("Toggle Value Name must not exceed 25 Characters")
        //    .MinimumLength(3).WithMessage("Toggle Value Name should not be less than 3 characters");

    }
}










































