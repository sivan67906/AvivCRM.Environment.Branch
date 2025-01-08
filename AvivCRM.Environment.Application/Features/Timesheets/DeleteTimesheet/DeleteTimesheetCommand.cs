#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.DeleteTimesheet;
public record DeleteTimesheetCommand(Guid Id) : IRequest<ServerResponse>;