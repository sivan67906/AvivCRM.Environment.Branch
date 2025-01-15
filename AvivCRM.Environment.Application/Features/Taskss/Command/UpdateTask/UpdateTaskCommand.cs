using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.Command.UpdateTask;
public record UpdateTasksCommand(UpdateTasksRequest Tasks) : IRequest<ServerResponse>;
