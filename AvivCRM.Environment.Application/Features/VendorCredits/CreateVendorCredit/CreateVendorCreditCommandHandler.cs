using AutoMapper; using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Application.DTOs.VendorCredit;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.CreateVendorCredit;
internal class CreateVendorCreditCommandHandler(IValidator<CreateVendorCreditRequest> _validator, IVendorCredit _vendorCreditRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<CreateVendorCreditCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateVendorCreditCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.VendorCredit);

        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));


        // Map the request to the entity
        var vendorCreditEntity = mapper.Map<VendorCredit>(request.VendorCredit);

        try
        {
            // Add the vendorCredit
            _vendorCreditRepository.Add(vendorCreditEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "VendorCredit created successfully", Data: vendorCreditEntity);
    }
}
