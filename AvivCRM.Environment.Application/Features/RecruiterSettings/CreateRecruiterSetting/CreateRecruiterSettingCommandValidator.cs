using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.CreateRecruiterSetting;

public class CreateRecruiterSettingCommandValidator : AbstractValidator<CreateRecruiterSettingRequest>
{
    public CreateRecruiterSettingCommandValidator()
    {
        RuleFor(x => x.RecruiterName)
            .NotEmpty().WithMessage("Recruiter Setting Name not empty")
            .MaximumLength(25).WithMessage("Recruiter Setting Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Recruiter Setting Name should not be less than 3 characters");

    }
}











