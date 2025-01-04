using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketChannels.GetAllTicketChannel;
internal class GetAllTicketChannelQueryHandler(ITicketChannel _ticketChannelRepository, IMapper mapper) : IRequestHandler<GetAllTicketChannelQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTicketChannelQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var ticketChannel = await _ticketChannelRepository.GetAllAsync();
        if (ticketChannel is null) return new ServerResponse(Message: "No Ticket Channel Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetTicketChannel>>(ticketChannel);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Ticket Channel Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Ticket Channels", Data: leadSourcResponse);
    }
}











