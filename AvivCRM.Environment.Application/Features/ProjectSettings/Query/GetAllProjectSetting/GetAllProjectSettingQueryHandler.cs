#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.Query.GetAllProjectSetting;
internal class GetAllProjectSettingQueryHandler(IProjectSetting _projectSettingRepository, IMapper mapper)
    : IRequestHandler<GetAllProjectSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllProjectSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Project.ProjectSetting>? projectSetting = await _projectSettingRepository.GetAllAsync();
        if (projectSetting is null)
        {
            return new ServerResponse(Message: "No Project Setting Found");
        }

        // Map the plan types to the response
        IEnumerable<GetProjectSetting>? leadSourcResponse = mapper.Map<IEnumerable<GetProjectSetting>>(projectSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Project Setting Not Found");
        }

        return new ServerResponse(true, "List of Project Settings", leadSourcResponse);
    }
}