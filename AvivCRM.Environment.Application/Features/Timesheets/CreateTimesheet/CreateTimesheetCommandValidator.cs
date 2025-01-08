#region

using AvivCRM.Environment.Application.DTOs.Timesheets;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.CreateTimesheet;
public class CreateTimesheetCommandValidator : AbstractValidator<CreateTimesheetRequest>
{
}