#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.Query.GetAllPurchaseSetting;
internal class GetAllPurchaseSettingQueryHandler(IPurchaseSetting _purchaseSettingRepository, IMapper mapper)
    : IRequestHandler<GetAllPurchaseSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllPurchaseSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.PurchaseSetting>? purchaseSetting = await _purchaseSettingRepository.GetAllAsync();
        if (purchaseSetting is null)
        {
            return new ServerResponse(Message: "No Purchase Setting Found");
        }

        // Map the plan types to the response
        IEnumerable<GetPurchaseSetting>? purchaseSettingResponse = mapper.Map<IEnumerable<GetPurchaseSetting>>(purchaseSetting);
        if (purchaseSettingResponse is null)
        {
            return new ServerResponse(Message: "Purchase Setting Not Found");
        }

        return new ServerResponse(true, "List of Purchase Settings", purchaseSettingResponse);
    }
}