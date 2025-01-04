using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.UpdateProjectStatus;

internal class UpdateProjectStatusCommandHandler(IValidator<UpdateProjectStatusRequest> _validator, IProjectStatus _projectStatusRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateProjectStatusCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.ProjectStatus);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var projectStatus = await _projectStatusRepository.GetByIdAsync(request.ProjectStatus.Id);
        if (projectStatus is null) return new ServerResponse(Message: "Project Status Not Found");

        // Map the request to the entity
        var projectStatusEntity = mapper.Map<ProjectStatus>(request.ProjectStatus);

        try
        {
            // Update the lead Source
            _projectStatusRepository.Update(projectStatusEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Project Status updated successfully", Data: projectStatus);
    }
}









