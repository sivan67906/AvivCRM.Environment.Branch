using AutoMapper; using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Application.DTOs.BillOrders;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.UpdateBillOrder;
internal class UpdateBillOrderCommandHandler(IValidator<UpdateBillOrderRequest> _validator, IBillOrder _billOrderRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateBillOrderCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateBillOrderCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.BillOrder);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the BillOrder exists
        var billOrder = await _billOrderRepository.GetByIdAsync(request.BillOrder.Id);
        if (billOrder is null) return new ServerResponse(Message: "BillOrder Not Found");

        // Map the request to the entity
        var billOrderEntity = mapper.Map<BillOrder>(request.BillOrder);

        try
        {
            // Update the BillOrder
            _billOrderRepository.Update(billOrderEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "BillOrder updated successfully", Data: billOrderEntity);
    }
}