using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.CreateFinancePrefixSetting;

public class CreateFinancePrefixSettingCommandValidator : AbstractValidator<CreateFinancePrefixSettingRequest>
{
    public CreateFinancePrefixSettingCommandValidator()
    {
        //RuleFor(x => x.FICBPrefixJsonSettings)
        //    .NotEmpty().WithMessage("Finance Prefix Setting Name should not be empty");

    }
}











