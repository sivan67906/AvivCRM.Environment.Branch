#region

using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectSettings.UpdateProjectSetting;
public class UpdateProjectSettingCommandValidator : AbstractValidator<UpdateProjectSettingRequest>
{
    public UpdateProjectSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Project SettingId should not be empty");

        //RuleFor(x => x.Name)
        //            .NotEmpty().WithMessage("Project Setting Name not empty")
        //            .MaximumLength(25).WithMessage("Project Setting Name must not exceed 25 Characters")
        //            .MinimumLength(3).WithMessage("Project Setting Name should not be less than 3 characters");
    }
}