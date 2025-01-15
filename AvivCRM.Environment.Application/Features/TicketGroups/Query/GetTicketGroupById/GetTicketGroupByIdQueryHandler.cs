#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.Query.GetTicketGroupById;
internal class GetTicketGroupByIdQueryHandler(ITicketGroup ticketGroupRepository, IMapper mapper)
    : IRequestHandler<GetTicketGroupByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketGroupByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket Group by id
        Domain.Entities.Ticket.TicketGroup? ticketGroup = await ticketGroupRepository.GetByIdAsync(request.Id);
        if (ticketGroup is null)
        {
            return new ServerResponse(Message: "Ticket Group Not Found");
        }

        // Map the entity to the response
        GetTicketGroup? ticketGroupResponse = mapper.Map<GetTicketGroup>(ticketGroup); // <DTO> (parameter)
        if (ticketGroupResponse is null)
        {
            return new ServerResponse(Message: "Ticket Group Not Found");
        }

        return new ServerResponse(true, "List of Ticket Group", ticketGroupResponse);
    }
}