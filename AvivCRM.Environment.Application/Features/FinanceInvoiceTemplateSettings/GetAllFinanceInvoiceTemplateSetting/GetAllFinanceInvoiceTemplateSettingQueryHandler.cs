using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.GetAllFinanceInvoiceTemplateSetting;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.GetAllFinanceInvoiceTemplateSetting;
internal class GetAllFinanceInvoiceTemplateSettingQueryHandler(IFinanceInvoiceTemplateSetting _financeInvoiceTemplateSettingRepository, IMapper mapper) : IRequestHandler<GetAllFinanceInvoiceTemplateSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllFinanceInvoiceTemplateSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var financeInvoiceTemplateSetting = await _financeInvoiceTemplateSettingRepository.GetAllAsync();
        if (financeInvoiceTemplateSetting is null) return new ServerResponse(Message: "No Finance Invoice Template Setting Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetFinanceInvoiceTemplateSetting>>(financeInvoiceTemplateSetting);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Finance Invoice Template Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Finance Invoice Template Setting", Data: leadSourcResponse);
    }
}











