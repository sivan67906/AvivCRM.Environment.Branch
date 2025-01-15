#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.Command.DeleteProjectReminderPerson;
public record DeleteProjectReminderPersonCommand(Guid Id) : IRequest<ServerResponse>;