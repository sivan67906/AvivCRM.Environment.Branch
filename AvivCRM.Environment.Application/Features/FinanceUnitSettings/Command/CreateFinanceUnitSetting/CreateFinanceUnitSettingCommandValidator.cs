#region

using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.CreateFinanceUnitSetting;
public class CreateFinanceUnitSettingCommandValidator : AbstractValidator<CreateFinanceUnitSettingRequest>
{
    public CreateFinanceUnitSettingCommandValidator()
    {
        RuleFor(x => x.FUnitName)
            .NotEmpty().WithMessage("Finance Unit Setting Name should not be empty")
            .MaximumLength(25).WithMessage("Finance Unit Setting Name must not exceed 25 Characters")
            .MinimumLength(3).WithMessage("Finance Unit Setting Name should not be less than 3 characters");
    }
}