using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketAgents.CreateTicketAgent;

internal class CreateTicketAgentCommandHandler(IValidator<CreateTicketAgentRequest> validator,
    ITicketAgent _ticketAgentRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateTicketAgentCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateTicketAgentCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.TicketAgent);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var ticketAgentEntity = mapper.Map<TicketAgent>(request.TicketAgent);

        try
        {
            _ticketAgentRepository.Add(ticketAgentEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Ticket Agent Created Succcessfully", Data: ticketAgentEntity);
    }
}











