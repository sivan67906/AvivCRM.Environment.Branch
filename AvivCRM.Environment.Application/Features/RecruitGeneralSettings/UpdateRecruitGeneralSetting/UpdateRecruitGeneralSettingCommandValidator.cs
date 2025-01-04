using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.UpdateRecruitGeneralSetting;

public class UpdateRecruitGeneralSettingCommandValidator : AbstractValidator<UpdateRecruitGeneralSettingRequest>
{
    public UpdateRecruitGeneralSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Recruit General Setting Id should not be empty");

        //RuleFor(x => x.Name)
        //            .NotEmpty().WithMessage("Recruit General Setting Name not empty")
        //            .MaximumLength(25).WithMessage("Recruit General Setting Name must not exceed 25 Characters")
        //            .MinimumLength(3).WithMessage("Recruit General Setting Name should not be less than 3 characters");

    }
}











