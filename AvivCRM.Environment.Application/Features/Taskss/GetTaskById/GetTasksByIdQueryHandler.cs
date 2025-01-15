using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.GetTaskById;

internal class GetTasksByIdQueryHandler(ITasks tasksRepository, IMapper mapper) : IRequestHandler<GetTasksByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTasksByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Tasks by id
        var tasks = await tasksRepository.GetByIdAsync(request.Id);
        if (tasks is null) return new ServerResponse(Message: "Task Not Found");

        // Map the entity to the response
        var tasksResponse = mapper.Map<GetTasks>(tasks); // <DTO> (parameter)
        if (tasksResponse is null) return new ServerResponse(Message: "Task Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Task", Data: tasksResponse);
    }
}