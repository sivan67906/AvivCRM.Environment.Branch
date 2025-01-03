using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.GetProjectReminderPersonById;

public record GetProjectReminderPersonByIdQuery(Guid Id) : IRequest<ServerResponse>;









