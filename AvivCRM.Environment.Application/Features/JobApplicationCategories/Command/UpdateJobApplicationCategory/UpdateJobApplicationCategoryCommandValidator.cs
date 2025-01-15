#region

using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationCategories.Command.UpdateJobApplicationCategory;
public class UpdateJobApplicationCategoryCommandValidator : AbstractValidator<UpdateJobApplicationCategoryRequest>
{
    public UpdateJobApplicationCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Job Application CategoryId should not be empty");

        RuleFor(x => x.JACategoryName)
            .NotEmpty().WithMessage("Job Application Category not empty")
            .MaximumLength(25).WithMessage("Job Application Category must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Job Application Category should not be less than 3 characters");
    }
}