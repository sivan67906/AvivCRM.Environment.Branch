#region

using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Command.UpdateFinanceInvoiceTemplateSetting;
public class
    UpdateFinanceInvoiceTemplateSettingCommandValidator : AbstractValidator<UpdateFinanceInvoiceTemplateSettingRequest>
{
    public UpdateFinanceInvoiceTemplateSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Finance Invoice Template Setting Id should not be empty");

        //RuleFor(x => x.FIRBTemplateJsonSettings)
        //            .NotEmpty().WithMessage("Finance Invoice Template Setting Name should not be empty");
    }
}