#region

using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.JobApplicationPositions.Command.UpdateJobApplicationPosition;
public class UpdateJobApplicationPositionCommandValidator : AbstractValidator<UpdateJobApplicationPositionRequest>
{
    public UpdateJobApplicationPositionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Job Application PositionId should not be empty");

        RuleFor(x => x.JAPositionName)
            .NotEmpty().WithMessage("Custom Question Name not empty")
            .MaximumLength(25).WithMessage("Custom Question Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Custom Question Name should not be less than 3 characters");
    }
}