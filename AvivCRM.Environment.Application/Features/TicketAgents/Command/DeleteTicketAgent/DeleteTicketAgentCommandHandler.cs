#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.Command.DeleteTicketAgent;
internal class DeleteTicketAgentCommandHandler(
    ITicketAgent _ticketAgentRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteTicketAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTicketAgentCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        TicketAgent? ticketAgent = await _ticketAgentRepository.GetByIdAsync(request.Id);
        if (ticketAgent is null)
        {
            return new ServerResponse(Message: "Ticket Agent Not Found");
        }

        // Map the request to the entity
        TicketAgent delMapEntity = mapper.Map<TicketAgent>(ticketAgent);

        try
        {
            // Delete plan type
            _ticketAgentRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Ticket Agent deleted successfully", delMapEntity);
    }
}