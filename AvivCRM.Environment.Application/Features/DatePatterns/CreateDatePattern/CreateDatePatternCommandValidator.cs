using AvivCRM.Environment.Application.DTOs.DatePatterns;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.DatePatterns.CreateDatePattern;

public class CreateDatePatternCommandValidator : AbstractValidator<CreateDatePatternRequest>
{
    public CreateDatePatternCommandValidator()
    {
		RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Source Code not empty")
            .MaximumLength(10).WithMessage("Source Code must not exceed 10 Characters")
            .MinimumLength(3).WithMessage("Source Code should not be less than 3 characters");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("DatePattern Name not empty")
            .MaximumLength(25).WithMessage("DatePattern Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("DatePattern Name should not be less than 3 characters");

    }
}
























