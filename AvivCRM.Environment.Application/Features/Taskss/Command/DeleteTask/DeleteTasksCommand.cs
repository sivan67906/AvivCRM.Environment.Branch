using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.Command.DeleteTask;
public record DeleteTasksCommand(Guid Id) : IRequest<ServerResponse>;
