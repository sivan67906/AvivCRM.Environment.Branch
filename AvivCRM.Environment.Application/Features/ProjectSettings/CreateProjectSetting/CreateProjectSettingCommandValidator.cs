using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.ProjectSettings.CreateProjectSetting;

public class CreateProjectSettingCommandValidator : AbstractValidator<CreateProjectSettingRequest>
{
    public CreateProjectSettingCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Project Setting Name not empty")
            .MaximumLength(25).WithMessage("Project Setting Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Project Setting Name should not be less than 3 characters");

    }
}











