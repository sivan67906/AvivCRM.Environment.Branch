using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using FluentValidation;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.UpdateFinanceInvoiceSetting;
public class UpdateFinanceInvoiceSettingCommandValidator : AbstractValidator<UpdateFinanceInvoiceSettingRequest>
{
    public UpdateFinanceInvoiceSettingCommandValidator()
    {
        RuleFor(x => x.FIDueAfter)
            .NotEmpty().WithMessage("Finance Invoice Setting date should not be empty");

    }
}
