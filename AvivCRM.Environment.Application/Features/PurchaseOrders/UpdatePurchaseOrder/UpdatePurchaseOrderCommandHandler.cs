using AutoMapper;
using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.UpdatePurchaseOrder;
internal class UpdatePurchaseOrderCommandHandler(IValidator<UpdatePurchaseOrderRequest> _validator, IPurchaseOrder _purchaseOrderRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdatePurchaseOrderCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.PurchaseOrder);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the PurchaseOrder exists
        var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(request.PurchaseOrder.Id);
        if (purchaseOrder is null) return new ServerResponse(Message: "PurchaseOrder Not Found");

        // Map the request to the entity
        var purchaseOrderEntity = mapper.Map<PurchaseOrder>(request.PurchaseOrder);

        try
        {
            // Update the PurchaseOrder
            _purchaseOrderRepository.Update(purchaseOrderEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "PurchaseOrder updated successfully", Data: purchaseOrderEntity);
    }
}