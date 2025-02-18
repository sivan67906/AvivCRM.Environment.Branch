#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.Command.UpdateProjectSetting;
internal class UpdateProjectSettingCommandHandler(
    IValidator<UpdateProjectSettingRequest> _validator,
    IProjectSetting _projectSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateProjectSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateProjectSettingCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.ProjectSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Project Setting exists
        ProjectSetting? projectSetting = await _projectSettingRepository.GetByIdAsync(request.ProjectSetting.Id);
        if (projectSetting is null)
        {
            return new ServerResponse(Message: "Project Setting Not Found");
        }

        // Map the request to the entity
        ProjectSetting projectSettingEntity = mapper.Map<ProjectSetting>(request.ProjectSetting);

        try
        {
            // Update the lead Source
            _projectSettingRepository.Update(projectSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Project Setting updated successfully", projectSettingEntity);
    }
}