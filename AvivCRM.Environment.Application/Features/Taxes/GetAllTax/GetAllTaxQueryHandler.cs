#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.GetAllTax;
internal class GetAllTaxQueryHandler(ITax _taxRepository, IMapper mapper)
    : IRequestHandler<GetAllTaxQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTaxQuery request, CancellationToken cancellationToken)
    {
        // Get all tax
        var tax = await _taxRepository.GetAllAsync();
        if (tax is null)
        {
            return new ServerResponse(Message: "No Tax Found");
        }

        // Map the tax to the response
        var taxResponse = mapper.Map<IEnumerable<GetTax>>(tax);
        if (taxResponse is null)
        {
            return new ServerResponse(Message: "Tax Not Found");
        }

        return new ServerResponse(true, "List of Taxes", taxResponse);
    }
}