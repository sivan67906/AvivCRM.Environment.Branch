#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.UpdatePayment;
internal class UpdatePaymentCommandHandler(
    IValidator<UpdatePaymentRequest> _validator,
    IPayment _paymentRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdatePaymentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Payment);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Payment exists
        var payment = await _paymentRepository.GetByIdAsync(request.Payment.Id);
        if (payment is null)
        {
            return new ServerResponse(Message: "Payment Not Found");
        }

        // Map the request to the entity
        var paymentEntity = mapper.Map<Payment>(request.Payment);

        try
        {
            // Update the Payment
            _paymentRepository.Update(paymentEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Payment updated successfully", paymentEntity);
    }
}