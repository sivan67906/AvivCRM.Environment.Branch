using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetFinanceInvoiceSettingById;
public record GetFinanceInvoiceSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;
