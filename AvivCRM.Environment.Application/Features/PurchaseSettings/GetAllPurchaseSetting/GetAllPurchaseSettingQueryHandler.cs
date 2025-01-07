using AutoMapper;
using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Application.Features.PurchaseSettings.GetAllPurchaseSetting;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.GetAllPurchaseSetting;
internal class GetAllPurchaseSettingQueryHandler(IPurchaseSetting _purchaseSettingRepository, IMapper mapper) : IRequestHandler<GetAllPurchaseSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllPurchaseSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var purchaseSetting = await _purchaseSettingRepository.GetAllAsync();
        if (purchaseSetting is null) return new ServerResponse(Message: "No Purchase Setting Found");

        // Map the plan types to the response
        var purchaseSettingResponse = mapper.Map<IEnumerable<GetPurchaseSetting>>(purchaseSetting);
        if (purchaseSettingResponse is null) return new ServerResponse(Message: "Purchase Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Purchase Settings", Data: purchaseSettingResponse);
    }
}















