using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.CreateCustomQuestionPosition;

public class CreateCustomQuestionPositionCommandValidator : AbstractValidator<CreateCustomQuestionPositionRequest>
{
    public CreateCustomQuestionPositionCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Custom Question Name not empty")
            .MaximumLength(25).WithMessage("Custom Question Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Custom Question Name should not be less than 3 characters");

    }
}











