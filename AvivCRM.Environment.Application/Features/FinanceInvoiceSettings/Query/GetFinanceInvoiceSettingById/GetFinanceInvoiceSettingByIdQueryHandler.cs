#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.Query.GetFinanceInvoiceSettingById;
internal class GetFinanceInvoiceSettingByIdQueryHandler(
    IFinanceInvoiceSetting financeInvoiceSettingRepository,
    IMapper mapper) : IRequestHandler<GetFinanceInvoiceSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetFinanceInvoiceSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Finance Invoice  Setting by id
        Domain.Entities.Finance.FinanceInvoiceSetting? financeInvoiceSetting = await financeInvoiceSettingRepository.GetByIdAsync(request.Id);
        if (financeInvoiceSetting is null)
        {
            return new ServerResponse(Message: "Finance Invoice Setting Not Found");
        }

        // Map the entity to the response
        GetFinanceInvoiceSetting? financeInvoiceSettingResponse =
            mapper.Map<GetFinanceInvoiceSetting>(financeInvoiceSetting); // <DTO> (parameter)
        if (financeInvoiceSettingResponse is null)
        {
            return new ServerResponse(Message: "Finance Invoice Setting Not Found");
        }

        return new ServerResponse(true, "List of Finance Invoice Setting", financeInvoiceSettingResponse);
    }
}