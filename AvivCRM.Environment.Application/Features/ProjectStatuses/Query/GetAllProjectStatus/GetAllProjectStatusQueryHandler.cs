#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Query.GetAllProjectStatus;
internal class GetAllProjectStatusQueryHandler(IProjectStatus _projectStatusRepository, IMapper mapper)
    : IRequestHandler<GetAllProjectStatusQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllProjectStatusQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Project.ProjectStatus>? projectStatus = await _projectStatusRepository.GetAllAsync();
        if (projectStatus is null)
        {
            return new ServerResponse(Message: "No Project Status Found");
        }

        // Map the plan types to the response
        IEnumerable<GetProjectStatus>? leadSourcResponse = mapper.Map<IEnumerable<GetProjectStatus>>(projectStatus);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Project Status Not Found");
        }

        return new ServerResponse(true, "List of Project Statuses", leadSourcResponse);
    }
}