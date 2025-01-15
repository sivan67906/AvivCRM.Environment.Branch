using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.DeleteBillOrder;
internal class DeleteBillOrderCommandHandler(IBillOrder _billOrderRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteBillOrderCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteBillOrderCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var billOrder = await _billOrderRepository.GetByIdAsync(request.Id);
        if (billOrder is null) return new ServerResponse(Message: "BillOrder Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<BillOrder>(billOrder);

        try
        {
            // Delete BillOrder
            _billOrderRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "BillOrder deleted successfully", Data: delMapEntity);
    }
}
