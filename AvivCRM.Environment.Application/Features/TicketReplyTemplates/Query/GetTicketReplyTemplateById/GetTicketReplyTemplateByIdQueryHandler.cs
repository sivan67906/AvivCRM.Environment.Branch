#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.Query.GetTicketReplyTemplateById;
internal class GetTicketReplyTemplateByIdQueryHandler(
    ITicketReplyTemplate ticketReplyTemplateRepository,
    IMapper mapper) : IRequestHandler<GetTicketReplyTemplateByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketReplyTemplateByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Ticket ReplyTemplate by id
        Domain.Entities.Ticket.TicketReplyTemplate? ticketReplyTemplate = await ticketReplyTemplateRepository.GetByIdAsync(request.Id);
        if (ticketReplyTemplate is null)
        {
            return new ServerResponse(Message: "Ticket ReplyTemplate Not Found");
        }

        // Map the entity to the response
        GetTicketReplyTemplate? ticketReplyTemplateResponse = mapper.Map<GetTicketReplyTemplate>(ticketReplyTemplate); // <DTO> (parameter)
        if (ticketReplyTemplateResponse is null)
        {
            return new ServerResponse(Message: "Ticket ReplyTemplate Not Found");
        }

        return new ServerResponse(true, "List of Ticket ReplyTemplate", ticketReplyTemplateResponse);
    }
}