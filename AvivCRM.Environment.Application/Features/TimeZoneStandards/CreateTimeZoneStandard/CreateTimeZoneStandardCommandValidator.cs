using AvivCRM.Environment.Application.DTOs.TimeZoneStandards;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TimeZoneStandards.CreateTimeZoneStandard;

public class CreateTimeZoneStandardCommandValidator : AbstractValidator<CreateTimeZoneStandardRequest>
{
    public CreateTimeZoneStandardCommandValidator()
    {
		RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Source Code not empty")
            .MaximumLength(10).WithMessage("Source Code must not exceed 10 Characters")
            .MinimumLength(3).WithMessage("Source Code should not be less than 3 characters");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("TimeZone Name not empty")
            .MaximumLength(25).WithMessage("TimeZone Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("TimeZone Name should not be less than 3 characters");

    }
}
























