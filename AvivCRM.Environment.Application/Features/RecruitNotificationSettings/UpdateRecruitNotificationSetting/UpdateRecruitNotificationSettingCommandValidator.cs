using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruitNotificationSettings.UpdateRecruitNotificationSetting;

public class UpdateRecruitNotificationSettingCommandValidator : AbstractValidator<UpdateRecruitNotificationSettingRequest>
{
    public UpdateRecruitNotificationSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Recruit Notification Setting Id should not be empty");

        //RuleFor(x => x.CBEMailJsonSettings)
        //    .NotEmpty().WithMessage("Recruit Mail Json Setting should not be empty");
        //RuleFor(x => x.CBEMailNotificationJsonSettings)
        //    .NotEmpty().WithMessage("Recruit Notification Mail Json Setting should not be empty");

    }
}











