using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectCategories.DeleteProjectCategory;

internal class DeleteProjectCategoryCommandHandler(IProjectCategory _projectCategoryRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteProjectCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteProjectCategoryCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var projectCategory = await _projectCategoryRepository.GetByIdAsync(request.Id);
        if (projectCategory is null) return new ServerResponse(Message: "Project Category Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<ProjectCategory>(projectCategory);

        try
        {
            // Delete plan type
            _projectCategoryRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Project Category Deleted Successfully", Data: projectCategory);
    }
}











