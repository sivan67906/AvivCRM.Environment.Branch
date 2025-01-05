using AutoMapper;
using AvivCRM.Environment.Application.DTOs.VendorCredit;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.GetVendorCreditById;
internal class GetVendorCreditByIdQueryHandler(IVendorCredit vendorCreditRepository, IMapper mapper) : IRequestHandler<GetVendorCreditByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetVendorCreditByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the VendorCredit by id
        var vendorCredit = await vendorCreditRepository.GetByIdAsync(request.Id);
        if (vendorCredit is null) return new ServerResponse(Message: "VendorCredit Not Found");

        // Map the entity to the response
        var vendorCreditResponse = mapper.Map<GetVendorCredit>(vendorCredit); // <DTO> (parameter)
        if (vendorCreditResponse is null) return new ServerResponse(Message: "VendorCredit Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of VendorCredit", Data: vendorCreditResponse);
    }
}