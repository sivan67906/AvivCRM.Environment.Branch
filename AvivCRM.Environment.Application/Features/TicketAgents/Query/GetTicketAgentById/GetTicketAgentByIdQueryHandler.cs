#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.Query.GetTicketAgentById;
internal class GetTicketAgentByIdQueryHandler(ITicketAgent ticketAgentRepository, IMapper mapper)
    : IRequestHandler<GetTicketAgentByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketAgentByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket Agent by id
        Domain.Entities.Ticket.TicketAgent? ticketAgent = await ticketAgentRepository.GetByIdAsync(request.Id);
        if (ticketAgent is null)
        {
            return new ServerResponse(Message: "Ticket Agent Not Found");
        }

        // Map the entity to the response
        GetTicketAgent? ticketAgentResponse = mapper.Map<GetTicketAgent>(ticketAgent); // <DTO> (parameter)
        if (ticketAgentResponse is null)
        {
            return new ServerResponse(Message: "Ticket Agent Not Found");
        }

        return new ServerResponse(true, "List of Ticket Agent", ticketAgentResponse);
    }
}