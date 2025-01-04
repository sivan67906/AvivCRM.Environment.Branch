using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.CustomQuestionPositions.UpdateCustomQuestionPosition;

public class UpdateCustomQuestionPositionCommandValidator : AbstractValidator<UpdateCustomQuestionPositionRequest>
{
    public UpdateCustomQuestionPositionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Custom Question PositionId should not be empty");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Custom Question Name not empty")
                    .MaximumLength(25).WithMessage("Custom Question Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Custom Question Name should not be less than 3 characters");

    }
}











