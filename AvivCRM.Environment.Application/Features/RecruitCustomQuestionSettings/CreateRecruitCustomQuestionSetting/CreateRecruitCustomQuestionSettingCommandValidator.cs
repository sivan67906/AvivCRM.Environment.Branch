using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruitCustomQuestionSettings.CreateRecruitCustomQuestionSetting;

public class CreateRecruitCustomQuestionSettingCommandValidator : AbstractValidator<CreateRecruitCustomQuestionSettingRequest>
{
    public CreateRecruitCustomQuestionSettingCommandValidator()
    {
        RuleFor(x => x.CQQuestion)
            .NotEmpty().WithMessage("Recruit Custom Question Setting Name not empty")
            .MaximumLength(25).WithMessage("Recruit Custom Question Setting Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Recruit Custom Question Setting Name should not be less than 3 characters");

    }
}











