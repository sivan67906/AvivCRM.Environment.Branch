#region

using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.CreateTimesheet;
public record CreateTimesheetCommand(CreateTimesheetRequest Timesheet) : IRequest<ServerResponse>;