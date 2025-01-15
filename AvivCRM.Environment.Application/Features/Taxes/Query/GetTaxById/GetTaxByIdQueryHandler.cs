#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.Query.GetTaxById;
internal class GetTaxByIdQueryHandler(ITax taxRepository, IMapper mapper) : IRequestHandler<GetTaxByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Tax by id
        Domain.Entities.Tax? tax = await taxRepository.GetByIdAsync(request.Id);
        if (tax is null) return new ServerResponse(Message: "Tax Not Found");

        // Map the entity to the response
        GetTax? taxResponse = mapper.Map<GetTax>(tax); // <DTO> (parameter)
        if (taxResponse is null) return new ServerResponse(Message: "Tax Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Tax", Data: taxResponse);
    }
}