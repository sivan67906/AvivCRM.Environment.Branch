#region

using AvivCRM.Environment.Application.DTOs.Timesheets;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.Command.UpdateTimesheet;
public class UpdateTimesheetCommandValidator : AbstractValidator<UpdateTimesheetRequest>
{
    public UpdateTimesheetCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("TimesheetId should not be empty");

        //RuleFor(x => x.Name)
        //            .NotEmpty().WithMessage("Timesheet Name not empty")
        //            .MaximumLength(25).WithMessage("Timesheet Name must not exceed 25 Characters")
        //            .MinimumLength(3).WithMessage("Timesheet Name should not be less than 3 characters");
    }
}