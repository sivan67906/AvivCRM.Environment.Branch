#region

using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.CreateRecruitJobApplicationStatusSetting;
public class
    CreateRecruitJobApplicationStatusSettingCommandValidator : AbstractValidator<
    CreateRecruitJobApplicationStatusSettingRequest>
{
    public CreateRecruitJobApplicationStatusSettingCommandValidator()
    {
        RuleFor(x => x.JASStatus)
            .NotEmpty().WithMessage("Recruit JobApplication Status Setting Name not empty")
            .MaximumLength(25).WithMessage("Recruit JobApplication Status Setting Name must not exceed 25 Characters")
            .MinimumLength(3)
            .WithMessage("Recruit JobApplication Status Setting Name should not be less than 3 characters");
    }
}