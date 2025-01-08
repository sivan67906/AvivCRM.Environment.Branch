#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.GetAllTicketAgent;
internal class GetAllTicketAgentQueryHandler(ITicketAgent _ticketAgentRepository, IMapper mapper)
    : IRequestHandler<GetAllTicketAgentQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTicketAgentQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var ticketAgent = await _ticketAgentRepository.GetAllAsync();
        if (ticketAgent is null)
        {
            return new ServerResponse(Message: "No Ticket Agent Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetTicketAgent>>(ticketAgent);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Ticket Agent Not Found");
        }

        return new ServerResponse(true, "List of Ticket Agents", leadSourcResponse);
    }
}