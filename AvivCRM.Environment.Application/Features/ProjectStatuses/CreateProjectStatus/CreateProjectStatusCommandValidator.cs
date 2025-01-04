using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.CreateProjectStatus;

public class CreateProjectStatusCommandValidator : AbstractValidator<CreateProjectStatusRequest>
{
    public CreateProjectStatusCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Project Status Name not empty")
            .MaximumLength(25).WithMessage("Project Status Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Project Status Name should not be less than 3 characters");

    }
}











