using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.DeleteFinanceInvoiceSetting;
public record DeleteFinanceInvoiceSettingCommand(Guid Id) : IRequest<ServerResponse>;
