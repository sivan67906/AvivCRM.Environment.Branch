using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectSettings.DeleteProjectSetting;

internal class DeleteProjectSettingCommandHandler(IProjectSetting _projectSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteProjectSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteProjectSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var projectSetting = await _projectSettingRepository.GetByIdAsync(request.Id);
        if (projectSetting is null) return new ServerResponse(Message: "Project Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<ProjectSetting>(projectSetting);

        try
        {
            // Delete plan type
            _projectSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Project Setting deleted successfully", Data: projectSetting);
    }
}











