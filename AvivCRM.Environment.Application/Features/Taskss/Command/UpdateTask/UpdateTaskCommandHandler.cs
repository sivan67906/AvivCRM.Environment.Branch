using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.Command.UpdateTask;

internal class UpdateTasksCommandHandler(IValidator<UpdateTasksRequest> _validator, ITasks _tasksRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateTasksCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTasksCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Tasks);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the tasks exists
        Tasks? tasks = await _tasksRepository.GetByIdAsync(request.Tasks.Id);
        if (tasks is null) return new ServerResponse(Message: "Task Not Found");

        // Map the request to the entity
        Tasks tasksEntity = mapper.Map<Tasks>(request.Tasks);

        try
        {
            // Update the tasks
            _tasksRepository.Update(tasksEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Task updated successfully", Data: tasksEntity);
    }
}
