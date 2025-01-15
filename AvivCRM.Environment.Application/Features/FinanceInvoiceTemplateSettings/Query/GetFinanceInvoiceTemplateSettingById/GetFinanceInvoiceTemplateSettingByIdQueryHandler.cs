#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Query.GetFinanceInvoiceTemplateSettingById;
internal class GetFinanceInvoiceTemplateSettingByIdQueryHandler(
    IFinanceInvoiceTemplateSetting financeInvoiceTemplateSettingRepository,
    IMapper mapper) : IRequestHandler<GetFinanceInvoiceTemplateSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetFinanceInvoiceTemplateSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Finance Invoice Template Setting by id
        Domain.Entities.Finance.FinanceInvoiceTemplateSetting? financeInvoiceTemplateSetting = await financeInvoiceTemplateSettingRepository.GetByIdAsync(request.Id);
        if (financeInvoiceTemplateSetting is null)
        {
            return new ServerResponse(Message: "Finance Invoice Template Setting Not Found");
        }

        // Map the entity to the response
        GetFinanceInvoiceTemplateSetting? financeInvoiceTemplateSettingResponse =
            mapper.Map<GetFinanceInvoiceTemplateSetting>(financeInvoiceTemplateSetting); // <DTO> (parameter)
        if (financeInvoiceTemplateSettingResponse is null)
        {
            return new ServerResponse(Message: "Finance Invoice Template Setting Not Found");
        }

        return new ServerResponse(true, "List of Finance Invoice Template Setting",
            financeInvoiceTemplateSettingResponse);
    }
}