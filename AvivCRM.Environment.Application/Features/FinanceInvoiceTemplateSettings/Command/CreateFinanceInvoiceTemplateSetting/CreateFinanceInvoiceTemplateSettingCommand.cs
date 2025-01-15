#region

using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Command.CreateFinanceInvoiceTemplateSetting;
public record CreateFinanceInvoiceTemplateSettingCommand(
    CreateFinanceInvoiceTemplateSettingRequest FinanceInvoiceTemplateSetting) : IRequest<ServerResponse>;