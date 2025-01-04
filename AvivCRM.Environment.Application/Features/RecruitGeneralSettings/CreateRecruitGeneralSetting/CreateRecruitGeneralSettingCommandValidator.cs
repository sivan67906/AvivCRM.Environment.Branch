using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.CreateRecruitGeneralSetting;

public class CreateRecruitGeneralSettingCommandValidator : AbstractValidator<CreateRecruitGeneralSettingRequest>
{
    public CreateRecruitGeneralSettingCommandValidator()
    {
        //RuleFor(x => x.Name)
        //    .NotEmpty().WithMessage("Recruit General Setting Name not empty")
        //    .MaximumLength(25).WithMessage("Recruit General Setting Name must not exceed 25 Characters")
        //    .MinimumLength(3).WithMessage("Recruit General Setting Name should not be less than 3 characters");

    }
}











