#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Command.DeleteProjectCategory;
internal class DeleteProjectCategoryCommandHandler(
    IProjectCategory _projectCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteProjectCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteProjectCategoryCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        ProjectCategory? projectCategory = await _projectCategoryRepository.GetByIdAsync(request.Id);
        if (projectCategory is null)
        {
            return new ServerResponse(Message: "Project Category Not Found");
        }

        // Map the request to the entity
        ProjectCategory delMapEntity = mapper.Map<ProjectCategory>(projectCategory);

        try
        {
            // Delete Project Category
            _projectCategoryRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Project Category deleted successfully", delMapEntity);
    }
}