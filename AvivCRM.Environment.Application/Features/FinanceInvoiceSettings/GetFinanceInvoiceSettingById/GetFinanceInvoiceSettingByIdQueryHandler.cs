using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetFinanceInvoiceSettingById;
internal class GetFinanceInvoiceSettingByIdQueryHandler(IFinanceInvoiceSetting financeInvoiceSettingRepository, IMapper mapper) : IRequestHandler<GetFinanceInvoiceSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetFinanceInvoiceSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Finance Invoice  Setting by id
        var financeInvoiceSetting = await financeInvoiceSettingRepository.GetByIdAsync(request.Id);
        if (financeInvoiceSetting is null) return new ServerResponse(Message: "Finance Invoice Setting Not Found");

        // Map the entity to the response
        var financeInvoiceSettingResponse = mapper.Map<GetFinanceInvoiceSetting>(financeInvoiceSetting); // <DTO> (parameter)
        if (financeInvoiceSettingResponse is null) return new ServerResponse(Message: "Finance Invoice Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Finance Invoice Setting", Data: financeInvoiceSettingResponse);
    }
}
