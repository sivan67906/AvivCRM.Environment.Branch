#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.GetAllTicketGroup;
internal class GetAllTicketGroupQueryHandler(ITicketGroup _ticketGroupRepository, IMapper mapper)
    : IRequestHandler<GetAllTicketGroupQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTicketGroupQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var ticketGroup = await _ticketGroupRepository.GetAllAsync();
        if (ticketGroup is null)
        {
            return new ServerResponse(Message: "No Ticket Group Found");
        }

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetTicketGroup>>(ticketGroup);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Ticket Group Not Found");
        }

        return new ServerResponse(true, "List of Ticket Groups", leadSourcResponse);
    }
}