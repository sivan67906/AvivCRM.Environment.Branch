#region

using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.UpdateFinanceInvoiceSetting;
public record UpdateFinanceInvoiceSettingCommand(UpdateFinanceInvoiceSettingRequest FinanceInvoiceSetting)
    : IRequest<ServerResponse>;