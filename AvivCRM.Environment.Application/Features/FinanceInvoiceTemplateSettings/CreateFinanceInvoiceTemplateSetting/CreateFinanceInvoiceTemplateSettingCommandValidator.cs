using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.CreateFinanceInvoiceTemplateSetting;

public class CreateFinanceInvoiceTemplateSettingCommandValidator : AbstractValidator<CreateFinanceInvoiceTemplateSettingRequest>
{
    public CreateFinanceInvoiceTemplateSettingCommandValidator()
    {
        //RuleFor(x => x.FIRBTemplateJsonSettings)
        //    .NotEmpty().WithMessage("Finance Invoice Template Setting Name should not be empty");

    }
}











