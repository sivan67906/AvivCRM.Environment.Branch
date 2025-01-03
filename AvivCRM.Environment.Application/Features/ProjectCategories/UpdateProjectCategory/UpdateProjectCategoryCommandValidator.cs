using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.ProjectCategories.UpdateProjectCategory;

public class UpdateProjectCategoryCommandValidator : AbstractValidator<UpdateProjectCategoryRequest>
{
    public UpdateProjectCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Project Category Id should not be empty");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Project Category Name should not be empty")
                    .MaximumLength(25).WithMessage("Project Category Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Project Category Name should not be less than 3 characters");

    }
}











