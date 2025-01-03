using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketTypes.GetTicketTypeById;

internal class GetTicketTypeByIdQueryHandler(ITicketType ticketTypeRepository, IMapper mapper) : IRequestHandler<GetTicketTypeByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketTypeByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket Type by id
        var ticketType = await ticketTypeRepository.GetByIdAsync(request.Id);
        if (ticketType is null) return new ServerResponse(Message: "Ticket Type Not Found");

        // Map the entity to the response
        var ticketTypeResponse = mapper.Map<GetTicketType>(ticketType); // <DTO> (parameter)
        if (ticketTypeResponse is null) return new ServerResponse(Message: "Ticket Type Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Ticket Type", Data: ticketTypeResponse);
    }
}









