using AutoMapper;
using AvivCRM.Environment.Application.DTOs.VendorCredit;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.UpdateVendorCredit;
internal class UpdateVendorCreditCommandHandler(IValidator<UpdateVendorCreditRequest> _validator, IVendorCredit _vendorCreditRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateVendorCreditCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateVendorCreditCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.VendorCredit);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the VendorCredit exists
        var vendorCredit = await _vendorCreditRepository.GetByIdAsync(request.VendorCredit.Id);
        if (vendorCredit is null) return new ServerResponse(Message: "VendorCredit Not Found");

        // Map the request to the entity
        var vendorCreditEntity = mapper.Map<VendorCredit>(request.VendorCredit);

        try
        {
            // Update the VendorCredit
            _vendorCreditRepository.Update(vendorCreditEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "VendorCredit updated successfully", Data: vendorCreditEntity);
    }
}