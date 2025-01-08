#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.UpdateProjectCategory;
internal class UpdateProjectCategoryCommandHandler(
    IValidator<UpdateProjectCategoryRequest> _validator,
    IProjectCategory _projectCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateProjectCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateProjectCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.ProjectCategory);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Project Category exists
        var projectCategory = await _projectCategoryRepository.GetByIdAsync(request.ProjectCategory.Id);
        if (projectCategory is null)
        {
            return new ServerResponse(Message: "Project Category Not Found");
        }

        // Map the request to the entity
        var projectCategoryEntity = mapper.Map<ProjectCategory>(request.ProjectCategory);

        try
        {
            // Update the Project Category
            _projectCategoryRepository.Update(projectCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Project Category updated successfully", projectCategoryEntity);
    }
}