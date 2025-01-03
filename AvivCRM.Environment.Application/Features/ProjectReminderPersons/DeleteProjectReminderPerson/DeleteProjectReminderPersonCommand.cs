using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.DeleteProjectReminderPerson;
public record DeleteProjectReminderPersonCommand(Guid Id) : IRequest<ServerResponse>;









