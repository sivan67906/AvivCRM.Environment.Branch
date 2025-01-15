#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.Query.GetAllProjectReminderPerson;
public record GetAllProjectReminderPersonQuery : IRequest<ServerResponse>;