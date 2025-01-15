#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Query.GetFinanceInvoiceTemplateSettingById;
public record GetFinanceInvoiceTemplateSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;