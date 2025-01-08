#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.CreateProjectSetting;
internal class CreateProjectSettingCommandHandler(
    IValidator<CreateProjectSettingRequest> validator,
    IProjectSetting _projectSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateProjectSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateProjectSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.ProjectSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var projectSettingEntity = mapper.Map<ProjectSetting>(request.ProjectSetting);

        try
        {
            _projectSettingRepository.Add(projectSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Project Setting created successfully", projectSettingEntity);
    }
}