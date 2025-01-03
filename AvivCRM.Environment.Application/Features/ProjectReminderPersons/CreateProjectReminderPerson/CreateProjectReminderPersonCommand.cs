using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.CreateProjectReminderPerson;

public record CreateProjectReminderPersonCommand(CreateProjectReminderPersonRequest ProjectReminderPerson) : IRequest<ServerResponse>;









