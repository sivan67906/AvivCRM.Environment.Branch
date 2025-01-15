#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.UpdateTicketAgent;
internal class UpdateTicketAgentCommandHandler(
    IValidator<UpdateTicketAgentRequest> _validator,
    ITicketAgent _ticketAgentRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateTicketAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTicketAgentCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.TicketAgent);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        var ticketAgent = await _ticketAgentRepository.GetByIdAsync(request.TicketAgent.Id);
        if (ticketAgent is null)
        {
            return new ServerResponse(Message: "Ticket Agent Not Found");
        }

        // Map the request to the entity
        var ticketAgentEntity = mapper.Map<TicketAgent>(request.TicketAgent);

        try
        {
            // Update the lead Source
            _ticketAgentRepository.Update(ticketAgentEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Ticket Agent updated successfully", ticketAgentEntity);
    }
}