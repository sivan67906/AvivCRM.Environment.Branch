#region

using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.Command.UpdateProjectReminderPerson;
public record UpdateProjectReminderPersonCommand(UpdateProjectReminderPersonRequest ProjectReminderPerson)
    : IRequest<ServerResponse>;