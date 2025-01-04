using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Timesheets.DeleteTimesheet;
public record DeleteTimesheetCommand(Guid Id) : IRequest<ServerResponse>;









