using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Timesheets.CreateTimesheet;

public record CreateTimesheetCommand(CreateTimesheetRequest Timesheet) : IRequest<ServerResponse>;









