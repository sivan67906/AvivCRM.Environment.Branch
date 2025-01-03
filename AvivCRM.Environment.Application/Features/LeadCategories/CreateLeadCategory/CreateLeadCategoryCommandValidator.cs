using AvivCRM.Environment.Application.DTOs.LeadCategories;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.LeadCategories.CreateLeadCategory;

public class CreateLeadCategoryCommandValidator : AbstractValidator<CreateLeadCategoryRequest>
{
    public CreateLeadCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Agent Name not empty")
            .MaximumLength(25).WithMessage("Agent Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Agent Name should not be less than 3 characters");

    }
}


