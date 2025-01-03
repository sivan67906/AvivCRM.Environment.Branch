using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketAgents.GetTicketAgentById;

internal class GetTicketAgentByIdQueryHandler(ITicketAgent ticketAgentRepository, IMapper mapper) : IRequestHandler<GetTicketAgentByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketAgentByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket Agent by id
        var ticketAgent = await ticketAgentRepository.GetByIdAsync(request.Id);
        if (ticketAgent is null) return new ServerResponse(Message: "Ticket Agent Not Found");

        // Map the entity to the response
        var ticketAgentResponse = mapper.Map<GetTicketAgent>(ticketAgent); // <DTO> (parameter)
        if (ticketAgentResponse is null) return new ServerResponse(Message: "Ticket Agent Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Ticket Agent", Data: ticketAgentResponse);
    }
}









