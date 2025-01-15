#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Query.GetProjectCategoryById;
internal class GetProjectCategoryByIdQueryHandler(IProjectCategory projectCategoryRepository, IMapper mapper)
    : IRequestHandler<GetProjectCategoryByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetProjectCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Project Category by id
        Domain.Entities.Project.ProjectCategory? projectCategory = await projectCategoryRepository.GetByIdAsync(request.Id);
        if (projectCategory is null)
        {
            return new ServerResponse(Message: "Project Category Not Found");
        }

        // Map the entity to the response
        GetProjectCategory? projectCategoryResponse = mapper.Map<GetProjectCategory>(projectCategory); // <DTO> (parameter)
        if (projectCategoryResponse is null)
        {
            return new ServerResponse(Message: "Project Category Not Found");
        }

        return new ServerResponse(true, "List of Project Category", projectCategoryResponse);
    }
}