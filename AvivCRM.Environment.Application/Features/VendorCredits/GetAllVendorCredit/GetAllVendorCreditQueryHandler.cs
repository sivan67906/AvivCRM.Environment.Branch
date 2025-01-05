using AutoMapper;
using AvivCRM.Environment.Application.DTOs.VendorCredit;
using AvivCRM.Environment.Domain.Contracts.Purchase;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.GetAllVendorCredit;
internal class GetAllVendorCreditQueryHandler(IVendorCredit _vendorCreditRepository, IMapper mapper) : IRequestHandler<GetAllVendorCreditQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllVendorCreditQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        var vendorCredit = await _vendorCreditRepository.GetAllAsync();
        if (vendorCredit is null) return new ServerResponse(Message: "No VendorCredit Found");

        // Map the VendorCredit to the response
        var vendorCreditResponse = mapper.Map<IEnumerable<GetVendorCredit>>(vendorCredit);
        if (vendorCreditResponse is null) return new ServerResponse(Message: "VendorCredit Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of VendorCredits", Data: vendorCreditResponse);
    }
}