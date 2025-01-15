using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taskss.CreateTask;
internal class CreateTasksCommandHandler(IValidator<CreateTasksRequest> validator,
    ITasks _tasksRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateTasksCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateTasksCommand request, CancellationToken cancellationToken)
    {
        // Check Validate Tasks
        var validate = await validator.ValidateAsync(request.Tasks);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }
        // Mapping Tasks Entity
        var tasksEntity = mapper.Map<Tasks>(request.Tasks);

        try
        {
            _tasksRepository.Add(tasksEntity);
            await _unitOfWork.SaveChangesAsync();  // Save Tasks
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Task created successfully", Data: tasksEntity);
    }
}