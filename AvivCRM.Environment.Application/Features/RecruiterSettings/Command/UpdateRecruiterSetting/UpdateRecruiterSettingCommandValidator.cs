#region

using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.Command.UpdateRecruiterSetting;
public class UpdateRecruiterSettingCommandValidator : AbstractValidator<UpdateRecruiterSettingRequest>
{
    public UpdateRecruiterSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Recruiter Setting Id should not be empty");

        RuleFor(x => x.RecruiterName)
            .NotEmpty().WithMessage("Recruiter Setting Name not empty")
            .MaximumLength(25).WithMessage("Recruiter Setting Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Recruiter Setting Name should not be less than 3 characters");
    }
}