#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.DeleteProjectSetting;
internal class DeleteProjectSettingCommandHandler(
    IProjectSetting _projectSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteProjectSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteProjectSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var projectSetting = await _projectSettingRepository.GetByIdAsync(request.Id);
        if (projectSetting is null)
        {
            return new ServerResponse(Message: "Project Setting Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<ProjectSetting>(projectSetting);

        try
        {
            // Delete Project Setting
            _projectSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Project Setting deleted successfully", delMapEntity);
    }
}