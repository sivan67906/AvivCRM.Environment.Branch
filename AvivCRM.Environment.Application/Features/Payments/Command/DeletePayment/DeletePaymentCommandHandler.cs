﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.Command.DeletePayment;
internal class DeletePaymentCommandHandler(IPayment _paymentRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeletePaymentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        Payment? payment = await _paymentRepository.GetByIdAsync(request.Id);
        if (payment is null)
        {
            return new ServerResponse(Message: "Payment Not Found");
        }

        // Map the request to the entity
        Payment delMapEntity = mapper.Map<Payment>(payment);

        try
        {
            // Delete Payment
            _paymentRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Payment deleted successfully", delMapEntity);
    }
}