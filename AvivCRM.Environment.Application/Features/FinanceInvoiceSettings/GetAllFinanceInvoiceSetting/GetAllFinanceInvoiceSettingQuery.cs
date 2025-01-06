using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetAllFinanceInvoiceSetting;
public record GetAllFinanceInvoiceSettingQuery : IRequest<ServerResponse>;
