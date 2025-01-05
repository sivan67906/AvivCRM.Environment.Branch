using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.GetAllPayment;
internal class GetAllPaymentQueryHandler(IPayment _paymentRepository, IMapper mapper) : IRequestHandler<GetAllPaymentQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
    {
        // Get all payments
        var payments = await _paymentRepository.GetAllAsync();
        if (payments is null) return new ServerResponse(Message: "No Payment Found");

        // Map the payments to the response
        var paymentResponse = mapper.Map<IEnumerable<GetPayment>>(payments);
        if (paymentResponse is null) return new ServerResponse(Message: "Payment Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Payment", Data: paymentResponse);
    }
}

