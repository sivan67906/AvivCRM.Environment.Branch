#region

using AvivCRM.Environment.Application.DTOs.Timesheets;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.Command.CreateTimesheet;
public class CreateTimesheetCommandValidator : AbstractValidator<CreateTimesheetRequest>
{
}