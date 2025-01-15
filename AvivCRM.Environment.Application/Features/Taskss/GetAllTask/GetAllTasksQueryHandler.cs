using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.GetAllTask;
internal class GetAllTasksQueryHandler(ITasks _tasksRepository, IMapper mapper) : IRequestHandler<GetAllTasksQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        // Get all tasks
        var tasks = await _tasksRepository.GetAllAsync();
        if (tasks is null) return new ServerResponse(Message: "No Task Found");

        // Map the tasks to the response
        var tasksResponse = mapper.Map<IEnumerable<GetTasks>>(tasks);
        if (tasksResponse is null) return new ServerResponse(Message: "Task Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Tasks", Data: tasksResponse);
    }
}