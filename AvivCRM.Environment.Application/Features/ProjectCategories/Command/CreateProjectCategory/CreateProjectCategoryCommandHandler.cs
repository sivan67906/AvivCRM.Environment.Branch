#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Command.CreateProjectCategory;
internal class CreateProjectCategoryCommandHandler(
    IValidator<CreateProjectCategoryRequest> validator,
    IProjectCategory _projectCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateProjectCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateProjectCategoryCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.ProjectCategory);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        ProjectCategory projectCategoryEntity = mapper.Map<ProjectCategory>(request.ProjectCategory);

        try
        {
            _projectCategoryRepository.Add(projectCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Project Category created successfully", projectCategoryEntity);
    }
}