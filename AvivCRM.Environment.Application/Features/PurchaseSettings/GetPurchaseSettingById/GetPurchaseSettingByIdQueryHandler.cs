using AutoMapper;
using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.GetPurchaseSettingById;

internal class GetPurchaseSettingByIdQueryHandler(IPurchaseSetting purchaseSettingRepository, IMapper mapper) : IRequestHandler<GetPurchaseSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetPurchaseSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Purchase Setting by id
        var purchaseSetting = await purchaseSettingRepository.GetByIdAsync(request.Id);
        if (purchaseSetting is null) return new ServerResponse(Message: "Purchase Setting Not Found");

        // Map the entity to the response
        var purchaseSettingResponse = mapper.Map<GetPurchaseSetting>(purchaseSetting); // <DTO> (parameter)
        if (purchaseSettingResponse is null) return new ServerResponse(Message: "Purchase Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Purchase Setting", Data: purchaseSettingResponse);
    }
}













