#region

using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectCategories.Command.CreateProjectCategory;
public class CreateProjectCategoryCommandValidator : AbstractValidator<CreateProjectCategoryRequest>
{
    public CreateProjectCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Project Category Name should not be empty")
            .MaximumLength(25).WithMessage("Project Category Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Project Category Name should not be less than 3 characters");
    }
}