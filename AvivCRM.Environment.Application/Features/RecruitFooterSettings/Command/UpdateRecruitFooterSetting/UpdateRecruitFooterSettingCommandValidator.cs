#region

using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.Command.UpdateRecruitFooterSetting;
public class UpdateRecruitFooterSettingCommandValidator : AbstractValidator<UpdateRecruitFooterSettingRequest>
{
    public UpdateRecruitFooterSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Recruit Footer Setting Id should not be empty");

        RuleFor(x => x.FooterTitle)
            .NotEmpty().WithMessage("Recruit Footer Title Name not empty")
            .MaximumLength(25).WithMessage("Recruit Footer Title Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Recruit Footer Title Name should not be less than 3 characters");
        RuleFor(x => x.FooterSlug)
            .NotEmpty().WithMessage("Recruit Footer Slug Name not empty")
            .MaximumLength(25).WithMessage("Recruit Footer Slug Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Recruit Footer Slug Name should not be less than 3 characters");
    }
}