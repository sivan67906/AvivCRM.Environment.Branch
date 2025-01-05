using AutoMapper;
using AvivCRM.Environment.Application.DTOs.BillOrders;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.GetBillOrderById;
internal class GetBillOrderByIdQueryHandler(IBillOrder billOrderRepository, IMapper mapper) : IRequestHandler<GetBillOrderByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetBillOrderByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the BillOrder by id
        var billOrder = await billOrderRepository.GetByIdAsync(request.Id);
        if (billOrder is null) return new ServerResponse(Message: "BillOrder Not Found");

        // Map the entity to the response
        var billOrderResponse = mapper.Map<GetBillOrder>(billOrder); // <DTO> (parameter)
        if (billOrderResponse is null) return new ServerResponse(Message: "BillOrder Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of BillOrder", Data: billOrderResponse);
    }
}