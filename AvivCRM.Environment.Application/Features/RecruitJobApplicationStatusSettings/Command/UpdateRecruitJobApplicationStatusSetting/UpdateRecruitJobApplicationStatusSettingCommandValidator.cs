#region

using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Command.UpdateRecruitJobApplicationStatusSetting;
public class
    UpdateRecruitJobApplicationStatusSettingCommandValidator : AbstractValidator<
    UpdateRecruitJobApplicationStatusSettingRequest>
{
    public UpdateRecruitJobApplicationStatusSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Recruit JobApplication Status Setting Id should not be empty");

        RuleFor(x => x.JASStatus)
            .NotEmpty().WithMessage("Recruit JobApplication Status Setting Name not empty")
            .MaximumLength(25).WithMessage("Recruit JobApplication Status Setting Name must not exceed 25 Characters")
            .MinimumLength(3)
            .WithMessage("Recruit JobApplication Status Setting Name should not be less than 3 characters");
    }
}