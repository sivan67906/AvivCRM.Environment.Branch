#region

using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.CustomQuestionTypes.Command.CreateCustomQuestionType;
public class CreateCustomQuestionTypeCommandValidator : AbstractValidator<CreateCustomQuestionTypeRequest>
{
    public CreateCustomQuestionTypeCommandValidator()
    {
        RuleFor(x => x.CQTypeCode)
            .NotEmpty().WithMessage("Custom Question Name not empty")
            .MaximumLength(10).WithMessage("Custom Question Name must not exceed 10 Characters")
            .MinimumLength(3).WithMessage("Custom Question Name should not be less than 3 characters");

        RuleFor(x => x.CQTypeName)
            .NotEmpty().WithMessage("Custom Question Name not empty")
            .MaximumLength(25).WithMessage("Custom Question Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Custom Question Name should not be less than 3 characters");
    }
}