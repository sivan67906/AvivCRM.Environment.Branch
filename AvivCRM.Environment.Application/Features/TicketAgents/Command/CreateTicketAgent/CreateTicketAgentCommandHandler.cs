#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketAgents.Command.CreateTicketAgent;
internal class CreateTicketAgentCommandHandler(
    IValidator<CreateTicketAgentRequest> validator,
    ITicketAgent _ticketAgentRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateTicketAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateTicketAgentCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.TicketAgent);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        TicketAgent ticketAgentEntity = mapper.Map<TicketAgent>(request.TicketAgent);

        try
        {
            _ticketAgentRepository.Add(ticketAgentEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Ticket Agent created successfully", ticketAgentEntity);
    }
}