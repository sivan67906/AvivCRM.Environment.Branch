#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.DeleteFinanceInvoiceTemplateSetting;
public record DeleteFinanceInvoiceTemplateSettingCommand(Guid Id) : IRequest<ServerResponse>;