#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Query.GetTicketTypeById;
internal class GetTicketTypeByIdQueryHandler(ITicketType ticketTypeRepository, IMapper mapper)
    : IRequestHandler<GetTicketTypeByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketTypeByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket Type by id
        Domain.Entities.Ticket.TicketType? ticketType = await ticketTypeRepository.GetByIdAsync(request.Id);
        if (ticketType is null)
        {
            return new ServerResponse(Message: "Ticket Type Not Found");
        }

        // Map the entity to the response
        GetTicketType? ticketTypeResponse = mapper.Map<GetTicketType>(ticketType); // <DTO> (parameter)
        if (ticketTypeResponse is null)
        {
            return new ServerResponse(Message: "Ticket Type Not Found");
        }

        return new ServerResponse(true, "List of Ticket Type", ticketTypeResponse);
    }
}