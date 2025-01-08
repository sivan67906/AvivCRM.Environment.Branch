#region

using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.UpdateProjectStatus;
public class UpdateProjectStatusCommandValidator : AbstractValidator<UpdateProjectStatusRequest>
{
    public UpdateProjectStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Project StatusId should not be empty");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Project Status Name not empty")
            .MaximumLength(25).WithMessage("Project Status Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Project Status Name should not be less than 3 characters");
    }
}