#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.Command.CreatePayment;
internal class CreatePaymentCommandHandler(
    IValidator<CreatePaymentRequest> _validator,
    IPayment _paymentRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreatePaymentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Payment);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }


        // Map the request to the entity
        Payment paymentEntity = mapper.Map<Payment>(request.Payment);

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

        return new ServerResponse(true, "Payment created successfully", paymentEntity);
    }
}