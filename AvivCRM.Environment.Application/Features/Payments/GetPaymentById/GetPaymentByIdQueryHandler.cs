using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.GetPaymentById;
internal class GetPaymentByIdQueryHandler(IPayment planTypeRepository, IMapper mapper) : IRequestHandler<GetPaymentByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the payment by id
        var payment = await planTypeRepository.GetByIdAsync(request.Id);
        if (payment is null) return new ServerResponse(Message: "Payment Not Found");

        // Map the entity to the response
        var paymentResponse = mapper.Map<GetPayment>(payment);
        if (paymentResponse is null) return new ServerResponse(Message: "Payment Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Payment", Data: paymentResponse);
    }
}