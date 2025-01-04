using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.CreateCustomQuestionType;

public class CreateCustomQuestionTypeCommandValidator : AbstractValidator<CreateCustomQuestionTypeRequest>
{
    public CreateCustomQuestionTypeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Custom Question Name not empty")
            .MaximumLength(25).WithMessage("Custom Question Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Custom Question Name should not be less than 3 characters");

    }
}











