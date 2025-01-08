using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.CreateTask;
public record CreateTasksCommand(CreateTasksRequest Tasks) : IRequest<ServerResponse>;