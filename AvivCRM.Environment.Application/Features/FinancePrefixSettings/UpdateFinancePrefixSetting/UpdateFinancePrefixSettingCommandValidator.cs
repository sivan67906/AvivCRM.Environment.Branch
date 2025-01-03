using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.UpdateFinancePrefixSetting;

public class UpdateFinancePrefixSettingCommandValidator : AbstractValidator<UpdateFinancePrefixSettingRequest>
{
    public UpdateFinancePrefixSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Finance Prefix Setting Id should not be empty");

        //RuleFor(x => x.FICBPrefixJsonSettings)
        //            .NotEmpty().WithMessage("Finance Prefix Setting Name should not be empty");
    }
}











