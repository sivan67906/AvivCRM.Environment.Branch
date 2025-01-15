#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.Command.DeleteFinanceInvoiceSetting;
public record DeleteFinanceInvoiceSettingCommand(Guid Id) : IRequest<ServerResponse>;