using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.DeletePurchaseOrder;
internal class DeletePurchaseOrderCommandHandler(IPurchaseOrder _purchaseOrderRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeletePurchaseOrderCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeletePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(request.Id);
        if (purchaseOrder is null) return new ServerResponse(Message: "PurchaseOrder Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<PurchaseOrder>(purchaseOrder);

        try
        {
            // Delete PurchaseOrder
            _purchaseOrderRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "PurchaseOrder deleted successfully", Data: delMapEntity);
    }
}