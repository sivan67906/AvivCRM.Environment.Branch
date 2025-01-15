#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Timesheets.Query.GetTimesheetById;
public record GetTimesheetByIdQuery(Guid Id) : IRequest<ServerResponse>;