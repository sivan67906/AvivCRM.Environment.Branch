using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.CreatePayment;
internal class CreatePaymentCommandHandler(IValidator<CreatePaymentRequest> _validator, IPayment _paymentRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<CreatePaymentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.Payment);

        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));


        // Map the request to the entity
        var paymentEntity = mapper.Map<Payment>(request.Payment);

        try
        {
            // Add the Payment
            _paymentRepository.Add(paymentEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Payment created successfully", Data: paymentEntity);
    }
}

