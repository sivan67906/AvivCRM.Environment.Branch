using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.UpdateFinanceUnitSetting;

public class UpdateFinanceUnitSettingCommandValidator : AbstractValidator<UpdateFinanceUnitSettingRequest>
{
    public UpdateFinanceUnitSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Finance Unit Setting Id should not be empty");

        RuleFor(x => x.FUnitName)
                    .NotEmpty().WithMessage("Finance Unit Setting Name should not be empty")
                    .MaximumLength(25).WithMessage("Finance Unit Setting Name must not exceed 25 Characters")
                    .MinimumLength(3).WithMessage("Finance Unit Setting Name should not be less than 3 characters");

    }
}











