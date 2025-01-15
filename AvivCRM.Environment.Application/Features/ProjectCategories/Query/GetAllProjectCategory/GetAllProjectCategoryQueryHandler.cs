#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Query.GetAllProjectCategory;
internal class GetAllProjectCategoryQueryHandler(IProjectCategory _projectCategoryRepository, IMapper mapper)
    : IRequestHandler<GetAllProjectCategoryQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllProjectCategoryQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Project.ProjectCategory>? projectCategory = await _projectCategoryRepository.GetAllAsync();
        if (projectCategory is null)
        {
            return new ServerResponse(Message: "No Project Category Found");
        }

        // Map the plan types to the response
        IEnumerable<GetProjectCategory>? leadSourcResponse = mapper.Map<IEnumerable<GetProjectCategory>>(projectCategory);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Project Category Not Found");
        }

        return new ServerResponse(true, "List of Project Categories", leadSourcResponse);
    }
}