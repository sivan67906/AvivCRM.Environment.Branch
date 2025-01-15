#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Query.GetAllFinanceInvoiceTemplateSetting;
public record GetAllFinanceInvoiceTemplateSettingQuery : IRequest<ServerResponse>;