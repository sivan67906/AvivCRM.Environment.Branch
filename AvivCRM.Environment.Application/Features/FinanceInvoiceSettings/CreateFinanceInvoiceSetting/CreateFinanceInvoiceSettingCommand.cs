using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.CreateFinanceInvoiceSetting;
public record CreateFinanceInvoiceSettingCommand(CreateFinanceInvoiceSettingRequest FinanceInvoiceSetting) : IRequest<ServerResponse>;
