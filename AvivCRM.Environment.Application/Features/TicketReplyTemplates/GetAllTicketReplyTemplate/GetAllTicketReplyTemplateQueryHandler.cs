using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.GetAllTicketReplyTemplate;
internal class GetAllTicketReplyTemplateQueryHandler(ITicketReplyTemplate _ticketReplyTemplateRepository, IMapper mapper) : IRequestHandler<GetAllTicketReplyTemplateQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllTicketReplyTemplateQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var ticketReplyTemplate = await _ticketReplyTemplateRepository.GetAllAsync();
        if (ticketReplyTemplate is null) return new ServerResponse(Message: "No Ticket ReplyTemplate Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetTicketReplyTemplate>>(ticketReplyTemplate);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Ticket ReplyTemplate Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Ticket ReplyTemplates", Data: leadSourcResponse);
    }
}











