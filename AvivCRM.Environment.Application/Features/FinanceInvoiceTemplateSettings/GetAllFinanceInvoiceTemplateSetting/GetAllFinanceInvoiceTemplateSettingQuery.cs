#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.GetAllFinanceInvoiceTemplateSetting;
public record GetAllFinanceInvoiceTemplateSettingQuery : IRequest<ServerResponse>;