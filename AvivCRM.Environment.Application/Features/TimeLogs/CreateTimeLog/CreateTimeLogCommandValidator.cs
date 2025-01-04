using AvivCRM.Environment.Application.DTOs.TimeLogs;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.TimeLogs.CreateTimeLog;

public class CreateTimeLogCommandValidator : AbstractValidator<CreateTimeLogRequest>
{
    public CreateTimeLogCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Time Log Name not empty")
            .MaximumLength(25).WithMessage("Time Log Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Time Log Name should not be less than 3 characters");

    }
}











