using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.GetAllTask;
public record GetAllTasksQuery : IRequest<ServerResponse>;

