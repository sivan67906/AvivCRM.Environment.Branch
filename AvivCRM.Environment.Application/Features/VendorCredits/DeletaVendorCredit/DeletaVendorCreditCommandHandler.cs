using AutoMapper; using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.DeletaVendorCredit;
internal class DeleteVendorCreditCommandHandler(IVendorCredit _vendorCreditRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteVendorCreditCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteVendorCreditCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var vendorCredit = await _vendorCreditRepository.GetByIdAsync(request.Id);
        if (vendorCredit is null) return new ServerResponse(Message: "VendorCredit Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<VendorCredit>(vendorCredit);

        try
        {
            // Delete VendorCredit
            _vendorCreditRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "VendorCredit deleted successfully", Data: delMapEntity);
    }
}