#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.DeleteFinanceInvoiceSetting;
public record DeleteFinanceInvoiceSettingCommand(Guid Id) : IRequest<ServerResponse>;