using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.GetFinanceInvoiceTemplateSettingById;

public record GetFinanceInvoiceTemplateSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









