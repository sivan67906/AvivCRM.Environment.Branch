using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.CreateRecruitFooterSetting;

public class CreateRecruitFooterSettingCommandValidator : AbstractValidator<CreateRecruitFooterSettingRequest>
{
    public CreateRecruitFooterSettingCommandValidator()
    {
        RuleFor(x => x.FooterTitle)
            .NotEmpty().WithMessage("Recruit Footer Setting Name not empty")
            .MaximumLength(25).WithMessage("Recruit Footer Setting Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Recruit Footer Setting Name should not be less than 3 characters");
        RuleFor(x => x.FooterSlug)
            .NotEmpty().WithMessage("Recruit Footer Setting Name not empty")
            .MaximumLength(25).WithMessage("Recruit Footer Setting Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Recruit Footer Setting Name should not be less than 3 characters");

    }
}











