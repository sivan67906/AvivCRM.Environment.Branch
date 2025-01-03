using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.CreateFinanceInvoiceTemplateSetting;

public record CreateFinanceInvoiceTemplateSettingCommand(CreateFinanceInvoiceTemplateSettingRequest FinanceInvoiceTemplateSetting) : IRequest<ServerResponse>;









