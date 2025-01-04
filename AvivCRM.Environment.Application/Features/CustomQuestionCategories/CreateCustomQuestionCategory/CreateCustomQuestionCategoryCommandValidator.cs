using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.CreateCustomQuestionCategory;

public class CreateCustomQuestionCategoryCommandValidator : AbstractValidator<CreateCustomQuestionCategoryRequest>
{
    public CreateCustomQuestionCategoryCommandValidator()
    {
        RuleFor(x => x.CQCategoryName)
            .NotEmpty().WithMessage("Custom Question Category Name not empty")
            .MaximumLength(25).WithMessage("Custom Question Category Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Custom Question Category Name should not be less than 3 characters");

    }
}











