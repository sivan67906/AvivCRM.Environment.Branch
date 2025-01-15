#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.Query.GetPaymentById;
internal class GetPaymentByIdQueryHandler(IPayment planTypeRepository, IMapper mapper)
    : IRequestHandler<GetPaymentByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the payment by id
        Domain.Entities.Payment? payment = await planTypeRepository.GetByIdAsync(request.Id);
        if (payment is null)
        {
            return new ServerResponse(Message: "Payment Not Found");
        }

        // Map the entity to the response
        GetPayment? paymentResponse = mapper.Map<GetPayment>(payment);
        if (paymentResponse is null)
        {
            return new ServerResponse(Message: "Payment Not Found");
        }

        return new ServerResponse(true, "List of Payment", paymentResponse);
    }
}