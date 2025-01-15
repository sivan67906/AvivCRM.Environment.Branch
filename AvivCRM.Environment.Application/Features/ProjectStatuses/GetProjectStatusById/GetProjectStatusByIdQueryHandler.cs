#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.GetProjectStatusById;
internal class GetProjectStatusByIdQueryHandler(IProjectStatus projectStatusRepository, IMapper mapper)
    : IRequestHandler<GetProjectStatusByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetProjectStatusByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Project Status by id
        var projectStatus = await projectStatusRepository.GetByIdAsync(request.Id);
        if (projectStatus is null)
        {
            return new ServerResponse(Message: "Project Status Not Found");
        }

        // Map the entity to the response
        var projectStatusResponse = mapper.Map<GetProjectStatus>(projectStatus); // <DTO> (parameter)
        if (projectStatusResponse is null)
        {
            return new ServerResponse(Message: "Project Status Not Found");
        }

        return new ServerResponse(true, "List of Project Status", projectStatusResponse);
    }
}