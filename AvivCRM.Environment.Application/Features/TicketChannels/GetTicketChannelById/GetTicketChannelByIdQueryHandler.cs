using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketChannels.GetTicketChannelById;

internal class GetTicketChannelByIdQueryHandler(ITicketChannel ticketChannelRepository, IMapper mapper) : IRequestHandler<GetTicketChannelByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketChannelByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket Channel by id
        var ticketChannel = await ticketChannelRepository.GetByIdAsync(request.Id);
        if (ticketChannel is null) return new ServerResponse(Message: "Ticket Channel Not Found");

        // Map the entity to the response
        var ticketChannelResponse = mapper.Map<GetTicketChannel>(ticketChannel); // <DTO> (parameter)
        if (ticketChannelResponse is null) return new ServerResponse(Message: "Ticket Channel Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Ticket Channel", Data: ticketChannelResponse);
    }
}









