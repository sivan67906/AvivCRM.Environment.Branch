using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.CreateJobApplicationPosition;

public class CreateJobApplicationPositionCommandValidator : AbstractValidator<CreateJobApplicationPositionRequest>
{
    public CreateJobApplicationPositionCommandValidator()
    {
        RuleFor(x => x.JAPositionName)
            .NotEmpty().WithMessage("Custom Question Name not empty")
            .MaximumLength(25).WithMessage("Custom Question Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Custom Question Name should not be less than 3 characters");

    }
}



















