#region

using AvivCRM.Environment.Application.DTOs.TimeLogs;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.TimeLogs.CreateTimeLog;
public class CreateTimeLogCommandValidator : AbstractValidator<CreateTimeLogRequest>
{
}