using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.ProjectCategories.CreateProjectCategory;

public class CreateProjectCategoryCommandValidator : AbstractValidator<CreateProjectCategoryRequest>
{
    public CreateProjectCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Project Category Name not empty")
            .MaximumLength(25).WithMessage("Project Category Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Project Category Name should not be less than 3 characters");

    }
}











