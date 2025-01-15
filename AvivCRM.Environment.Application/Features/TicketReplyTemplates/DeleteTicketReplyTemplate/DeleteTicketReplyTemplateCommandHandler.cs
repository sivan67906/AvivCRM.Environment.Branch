#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.DeleteTicketReplyTemplate;
internal class DeleteTicketReplyTemplateCommandHandler(
    ITicketReplyTemplate _ticketReplyTemplateRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteTicketReplyTemplateCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTicketReplyTemplateCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        var ticketReplyTemplate = await _ticketReplyTemplateRepository.GetByIdAsync(request.Id);
        if (ticketReplyTemplate is null)
        {
            return new ServerResponse(Message: "Ticket ReplyTemplate Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<TicketReplyTemplate>(ticketReplyTemplate);

        try
        {
            // Delete plan type
            _ticketReplyTemplateRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Ticket ReplyTemplate deleted successfully", delMapEntity);
    }
}