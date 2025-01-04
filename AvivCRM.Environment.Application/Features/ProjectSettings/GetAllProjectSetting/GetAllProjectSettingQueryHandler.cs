using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectSettings.GetAllProjectSetting;
internal class GetAllProjectSettingQueryHandler(IProjectSetting _projectSettingRepository, IMapper mapper) : IRequestHandler<GetAllProjectSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllProjectSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var projectSetting = await _projectSettingRepository.GetAllAsync();
        if (projectSetting is null) return new ServerResponse(Message: "No Project Setting Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetProjectSetting>>(projectSetting);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Project Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Project Settings", Data: leadSourcResponse);
    }
}











