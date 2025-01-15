using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.Query.GetAllTask;
internal class GetAllTasksQueryHandler(ITasks _tasksRepository, IMapper mapper) : IRequestHandler<GetAllTasksQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        // Get all tasks
        IEnumerable<Domain.Entities.Tasks>? tasks = await _tasksRepository.GetAllAsync();
        if (tasks is null) return new ServerResponse(Message: "No Task Found");

        // Map the tasks to the response
        IEnumerable<GetTasks>? tasksResponse = mapper.Map<IEnumerable<GetTasks>>(tasks);
        if (tasksResponse is null) return new ServerResponse(Message: "Task Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Tasks", Data: tasksResponse);
    }
}