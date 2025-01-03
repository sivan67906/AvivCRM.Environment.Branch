using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.DeleteFinanceInvoiceTemplateSetting;
public record DeleteFinanceInvoiceTemplateSettingCommand(Guid Id) : IRequest<ServerResponse>;









