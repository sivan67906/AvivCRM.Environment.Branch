using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.CustomQuestionCategories.UpdateCustomQuestionCategory;

public class UpdateCustomQuestionCategoryCommandValidator : AbstractValidator<UpdateCustomQuestionCategoryRequest>
{
    public UpdateCustomQuestionCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Custom Question Category Id should not be empty");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Custom Question Category Name not empty")
                    .MaximumLength(25).WithMessage("Custom Question Category Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Custom Question Category Name should not be less than 3 characters");

    }
}











