using AvivCRM.Environment.Application.DTOs.Timesheets;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.Timesheets.CreateTimesheet;

public class CreateTimesheetCommandValidator : AbstractValidator<CreateTimesheetRequest>
{
    public CreateTimesheetCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Timesheet Name not empty")
            .MaximumLength(25).WithMessage("Timesheet Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Timesheet Name should not be less than 3 characters");

    }
}











