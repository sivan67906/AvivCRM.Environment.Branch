using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.GetAllProjectStatus;
internal class GetAllProjectStatusQueryHandler(IProjectStatus _projectStatusRepository, IMapper mapper) : IRequestHandler<GetAllProjectStatusQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllProjectStatusQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var projectStatus = await _projectStatusRepository.GetAllAsync();
        if (projectStatus is null) return new ServerResponse(Message: "No Project Status Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetProjectStatus>>(projectStatus);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Project Status Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Project Statuses", Data: leadSourcResponse);
    }
}











