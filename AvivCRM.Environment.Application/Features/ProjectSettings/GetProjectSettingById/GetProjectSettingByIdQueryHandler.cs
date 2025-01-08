#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.GetProjectSettingById;
internal class GetProjectSettingByIdQueryHandler(IProjectSetting projectSettingRepository, IMapper mapper)
    : IRequestHandler<GetProjectSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetProjectSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Project Setting by id
        var projectSetting = await projectSettingRepository.GetByIdAsync(request.Id);
        if (projectSetting is null)
        {
            return new ServerResponse(Message: "Project Setting Not Found");
        }

        // Map the entity to the response
        var projectSettingResponse = mapper.Map<GetProjectSetting>(projectSetting); // <DTO> (parameter)
        if (projectSettingResponse is null)
        {
            return new ServerResponse(Message: "Project Setting Not Found");
        }

        return new ServerResponse(true, "List of Project Setting", projectSettingResponse);
    }
}