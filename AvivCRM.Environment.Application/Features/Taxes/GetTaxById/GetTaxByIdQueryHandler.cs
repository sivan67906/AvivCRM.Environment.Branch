#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.GetTaxById;
internal class GetTaxByIdQueryHandler(ITax ticketAgentRepository, IMapper mapper)
    : IRequestHandler<GetTaxByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Tax by id
        var ticketAgent = await ticketAgentRepository.GetByIdAsync(request.Id);
        if (ticketAgent is null)
        {
            return new ServerResponse(Message: "Tax Not Found");
        }

        // Map the entity to the response
        var ticketAgentResponse = mapper.Map<GetTax>(ticketAgent); // <DTO> (parameter)
        if (ticketAgentResponse is null)
        {
            return new ServerResponse(Message: "Tax Not Found");
        }

        return new ServerResponse(true, "List of Tax", ticketAgentResponse);
    }
}