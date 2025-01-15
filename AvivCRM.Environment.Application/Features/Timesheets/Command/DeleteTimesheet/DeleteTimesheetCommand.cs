#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.Command.DeleteTimesheet;
public record DeleteTimesheetCommand(Guid Id) : IRequest<ServerResponse>;