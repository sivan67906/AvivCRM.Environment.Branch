#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.Query.GetAllTimesheet;
public record GetAllTimesheetQuery : IRequest<ServerResponse>;