#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetAllFinanceInvoiceSetting;
public record GetAllFinanceInvoiceSettingQuery : IRequest<ServerResponse>;