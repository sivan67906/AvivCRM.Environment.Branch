#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.GetProjectCategoryById;
internal class GetProjectCategoryByIdQueryHandler(IProjectCategory projectCategoryRepository, IMapper mapper)
    : IRequestHandler<GetProjectCategoryByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetProjectCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Project Category by id
        var projectCategory = await projectCategoryRepository.GetByIdAsync(request.Id);
        if (projectCategory is null)
        {
            return new ServerResponse(Message: "Project Category Not Found");
        }

        // Map the entity to the response
        var projectCategoryResponse = mapper.Map<GetProjectCategory>(projectCategory); // <DTO> (parameter)
        if (projectCategoryResponse is null)
        {
            return new ServerResponse(Message: "Project Category Not Found");
        }

        return new ServerResponse(true, "List of Project Category", projectCategoryResponse);
    }
}