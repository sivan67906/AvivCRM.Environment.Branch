﻿#region

using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using FluentValidation;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.Command.CreateFinanceInvoiceSetting;
public class CreateFinanceInvoiceSettingCommandValidator : AbstractValidator<CreateFinanceInvoiceSettingRequest>
{
    public CreateFinanceInvoiceSettingCommandValidator()
    {
        RuleFor(x => x.FIDueAfter)
            .NotEmpty().WithMessage("Finance Invoice Setting date should not be empty");
    }
}