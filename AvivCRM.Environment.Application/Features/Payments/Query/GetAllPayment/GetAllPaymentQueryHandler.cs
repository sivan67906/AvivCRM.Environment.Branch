#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.Query.GetAllPayment;
internal class GetAllPaymentQueryHandler(IPayment _paymentRepository, IMapper mapper)
    : IRequestHandler<GetAllPaymentQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
    {
        // Get all payments
        IEnumerable<Domain.Entities.Payment>? payments = await _paymentRepository.GetAllAsync();
        if (payments is null)
        {
            return new ServerResponse(Message: "No Payment Found");
        }

        // Map the payments to the response
        IEnumerable<GetPayment>? paymentResponse = mapper.Map<IEnumerable<GetPayment>>(payments);
        if (paymentResponse is null)
        {
            return new ServerResponse(Message: "Payment Not Found");
        }

        return new ServerResponse(true, "List of Payments", paymentResponse);
    }
}