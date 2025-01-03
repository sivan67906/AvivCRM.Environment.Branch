using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.CreateRecruitNotificationSetting;

public class CreateRecruitNotificationSettingCommandValidator : AbstractValidator<CreateRecruitNotificationSettingRequest>
{
    public CreateRecruitNotificationSettingCommandValidator()
    {
        //RuleFor(x => x.CBEMailJsonSettings)
        //    .NotEmpty().WithMessage("Recruit Mail Json Setting should not be empty");
        //RuleFor(x => x.CBEMailNotificationJsonSettings)
        //    .NotEmpty().WithMessage("Recruit Notification Mail Json Setting should not be empty");

    }
}











