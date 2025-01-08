using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketAgents.DeleteTicketAgent;

internal class DeleteTicketAgentCommandHandler(ITicketAgent _ticketAgentRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteTicketAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTicketAgentCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var ticketAgent = await _ticketAgentRepository.GetByIdAsync(request.Id);
        if (ticketAgent is null) return new ServerResponse(Message: "Ticket Agent Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<TicketAgent>(ticketAgent);

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

        return new ServerResponse(IsSuccess: true, Message: "Ticket Agent deleted successfully", Data: delMapEntity);
    }
}