using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketTypes.GetAllTicketType;
internal class GetAllTicketTypeQueryHandler(ITicketType _ticketTypeRepository, IMapper mapper) : IRequestHandler<GetAllTicketTypeQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTicketTypeQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var ticketType = await _ticketTypeRepository.GetAllAsync();
        if (ticketType is null) return new ServerResponse(Message: "No Ticket Type Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetTicketType>>(ticketType);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Ticket Type Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Ticket Types", Data: leadSourcResponse);
    }
}











