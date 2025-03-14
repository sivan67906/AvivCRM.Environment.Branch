#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Query.GetTicketChannelById;
internal class GetTicketChannelByIdQueryHandler(ITicketChannel ticketChannelRepository, IMapper mapper)
    : IRequestHandler<GetTicketChannelByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketChannelByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket Channel by id
        Domain.Entities.Ticket.TicketChannel? ticketChannel = await ticketChannelRepository.GetByIdAsync(request.Id);
        if (ticketChannel is null)
        {
            return new ServerResponse(Message: "Ticket Channel Not Found");
        }

        // Map the entity to the response
        GetTicketChannel? ticketChannelResponse = mapper.Map<GetTicketChannel>(ticketChannel); // <DTO> (parameter)
        if (ticketChannelResponse is null)
        {
            return new ServerResponse(Message: "Ticket Channel Not Found");
        }

        return new ServerResponse(true, "List of Ticket Channel", ticketChannelResponse);
    }
}