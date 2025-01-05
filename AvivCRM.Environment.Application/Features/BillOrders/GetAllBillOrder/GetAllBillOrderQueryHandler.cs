using AutoMapper;
using AvivCRM.Environment.Application.DTOs.BillOrders;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.GetAllBillOrder;
internal class GetAllBillOrderQueryHandler(IBillOrder _billOrderRepository, IMapper mapper) : IRequestHandler<GetAllBillOrderQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllBillOrderQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        var billOrder = await _billOrderRepository.GetAllAsync();
        if (billOrder is null) return new ServerResponse(Message: "No BillOrder Found");

        // Map the BillOrder to the response
        var billOrderResponse = mapper.Map<IEnumerable<GetBillOrder>>(billOrder);
        if (billOrderResponse is null) return new ServerResponse(Message: "BillOrder Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of BillOrders", Data: billOrderResponse);
    }
}