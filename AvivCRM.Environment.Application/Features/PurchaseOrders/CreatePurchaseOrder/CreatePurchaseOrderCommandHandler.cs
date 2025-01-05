using AutoMapper;
using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.CreatePurchaseOrder;
internal class CreatePurchaseOrderCommandHandler(IValidator<CreatePurchaseOrderRequest> _validator, IPurchaseOrder _purchaseOrderRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<CreatePurchaseOrderCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.PurchaseOrder);

        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));


        // Map the request to the entity
        var purchaseOrderEntity = mapper.Map<PurchaseOrder>(request.PurchaseOrder);

        try
        {
            // Add the purchaseOrder
            _purchaseOrderRepository.Add(purchaseOrderEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "PurchaseOrder created successfully", Data: purchaseOrderEntity);
    }
}
