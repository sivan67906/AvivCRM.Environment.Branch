using AvivCRM.Environment.Application.DTOs.DatePatterns;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.DatePatterns.UpdateDatePattern;

public class UpdateDatePatternCommandValidator : AbstractValidator<UpdateDatePatternRequest>
{
    public UpdateDatePatternCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Source Id should not be empty");
		
		RuleFor(x => x.Code)
                    .NotEmpty().WithMessage("Source Code should not be empty")
                    .MaximumLength(10).WithMessage("Source Code must not exceed 10 Characters")
                    .MinimumLength(3).WithMessage("Source Code should not be less than 3 characters");
        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("DatePattern Name should not be empty")
                    .MaximumLength(25).WithMessage("DatePattern Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("DatePattern Name should not be less than 3 characters");

    }
}
























