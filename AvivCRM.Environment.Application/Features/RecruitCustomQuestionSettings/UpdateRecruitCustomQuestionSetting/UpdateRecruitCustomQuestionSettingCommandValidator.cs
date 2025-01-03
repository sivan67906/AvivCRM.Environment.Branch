using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.UpdateRecruitCustomQuestionSetting;

public class UpdateRecruitCustomQuestionSettingCommandValidator : AbstractValidator<UpdateRecruitCustomQuestionSettingRequest>
{
    public UpdateRecruitCustomQuestionSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Recruit Custom Question SettingId should not be empty");

        RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Recruit Custom Question Setting Name not empty")
                    .MaximumLength(25).WithMessage("Recruit Custom Question Setting Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Recruit Custom Question Setting Name should not be less than 3 characters");

    }
}











