using AutoMapper;
using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.GetAllPurchaseOrder;
internal class GetAllPurchaseOrderQueryHandler(IPurchaseOrder _purchaseOrderRepository, IMapper mapper) : IRequestHandler<GetAllPurchaseOrderQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllPurchaseOrderQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        var purchaseOrder = await _purchaseOrderRepository.GetAllAsync();
        if (purchaseOrder is null) return new ServerResponse(Message: "No PurchaseOrder Found");

        // Map the PurchaseOrder to the response
        var purchaseOrderResponse = mapper.Map<IEnumerable<GetPurchaseOrder>>(purchaseOrder);
        if (purchaseOrderResponse is null) return new ServerResponse(Message: "PurchaseOrder Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of PurchaseOrders", Data: purchaseOrderResponse);
    }
}