#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Query.GetAllTicketChannel;
internal class GetAllTicketChannelQueryHandler(ITicketChannel _ticketChannelRepository, IMapper mapper)
    : IRequestHandler<GetAllTicketChannelQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTicketChannelQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Ticket.TicketChannel>? ticketChannel = await _ticketChannelRepository.GetAllAsync();
        if (ticketChannel is null)
        {
            return new ServerResponse(Message: "No Ticket Channel Found");
        }

        // Map the plan types to the response
        IEnumerable<GetTicketChannel>? leadSourcResponse = mapper.Map<IEnumerable<GetTicketChannel>>(ticketChannel);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Ticket Channel Not Found");
        }

        return new ServerResponse(true, "List of Ticket Channels", leadSourcResponse);
    }
}