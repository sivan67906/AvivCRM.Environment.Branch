#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.GetProjectReminderPersonById;
public record GetProjectReminderPersonByIdQuery(Guid Id) : IRequest<ServerResponse>;