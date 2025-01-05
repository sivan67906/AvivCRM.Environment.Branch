using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.DeletePayment;
internal class DeletePaymentCommandHandler(IPayment _paymentRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeletePaymentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var payment = await _paymentRepository.GetByIdAsync(request.Id);
        if (payment is null) return new ServerResponse(Message: "Payment Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<Payment>(payment);

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

        return new ServerResponse(IsSuccess: true, Message: "Payment deleted successfully", Data: delMapEntity);
    }
}