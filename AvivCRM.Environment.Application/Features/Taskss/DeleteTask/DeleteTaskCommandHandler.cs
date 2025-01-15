using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.DeleteTask;
internal class DeleteTasksCommandHandler(ITasks _tasksRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteTasksCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTasksCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var tasks = await _tasksRepository.GetByIdAsync(request.Id);
        if (tasks is null) return new ServerResponse(Message: "Task Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<Tasks>(tasks);

        try
        {
            // Delete tasks
            _tasksRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Task deleted successfully", Data: delMapEntity);
    }
}