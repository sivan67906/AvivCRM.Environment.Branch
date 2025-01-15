#region

using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.Command.CreateProjectReminderPerson;
public record CreateProjectReminderPersonCommand(CreateProjectReminderPersonRequest ProjectReminderPerson)
    : IRequest<ServerResponse>;