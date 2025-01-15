#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.Query.GetAllFinanceInvoiceSetting;
public record GetAllFinanceInvoiceSettingQuery : IRequest<ServerResponse>;