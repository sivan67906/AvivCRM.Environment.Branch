using AutoMapper;
using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.GetPurchaseOrderById;
internal class GetPurchaseOrderByIdQueryHandler(IPurchaseOrder purchaseOrderRepository, IMapper mapper) : IRequestHandler<GetPurchaseOrderByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetPurchaseOrderByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the PurchaseOrder by id
        var purchaseOrder = await purchaseOrderRepository.GetByIdAsync(request.Id);
        if (purchaseOrder is null) return new ServerResponse(Message: "PurchaseOrder Not Found");

        // Map the entity to the response
        var purchaseOrderResponse = mapper.Map<GetPurchaseOrder>(purchaseOrder); // <DTO> (parameter)
        if (purchaseOrderResponse is null) return new ServerResponse(Message: "PurchaseOrder Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of PurchaseOrder", Data: purchaseOrderResponse);
    }
}