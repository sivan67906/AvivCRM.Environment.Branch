using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.GetTicketReplyTemplateById;

internal class GetTicketReplyTemplateByIdQueryHandler(ITicketReplyTemplate ticketReplyTemplateRepository, IMapper mapper) : IRequestHandler<GetTicketReplyTemplateByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetTicketReplyTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Ticket ReplyTemplate by id
        var ticketReplyTemplate = await ticketReplyTemplateRepository.GetByIdAsync(request.Id);
        if (ticketReplyTemplate is null) return new ServerResponse(Message: "Ticket ReplyTemplate Not Found");

        // Map the entity to the response
        var ticketReplyTemplateResponse = mapper.Map<GetTicketReplyTemplate>(ticketReplyTemplate); // <DTO> (parameter)
        if (ticketReplyTemplateResponse is null) return new ServerResponse(Message: "Ticket ReplyTemplate Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Ticket ReplyTemplate", Data: ticketReplyTemplateResponse);
    }
}









