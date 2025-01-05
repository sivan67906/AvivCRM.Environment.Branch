using AutoMapper;
using AvivCRM.Environment.Application.DTOs.BillOrders;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.CreateBillOrder;
internal class CreateBillOrderCommandHandler(IValidator<CreateBillOrderRequest> _validator, IBillOrder _billOrderRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<CreateBillOrderCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateBillOrderCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.BillOrder);

        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));


        // Map the request to the entity
        var billOrderEntity = mapper.Map<BillOrder>(request.BillOrder);

        try
        {
            // Add the billOrder
            _billOrderRepository.Add(billOrderEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "BillOrder created successfully", Data: billOrderEntity);
    }
}
