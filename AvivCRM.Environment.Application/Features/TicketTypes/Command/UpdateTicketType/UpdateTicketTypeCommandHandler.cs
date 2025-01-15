#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Command.UpdateTicketType;
internal class UpdateTicketTypeCommandHandler(
    IValidator<UpdateTicketTypeRequest> _validator,
    ITicketType _ticketTypeRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateTicketTypeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.TicketType);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        TicketType? ticketType = await _ticketTypeRepository.GetByIdAsync(request.TicketType.Id);
        if (ticketType is null)
        {
            return new ServerResponse(Message: "Ticket Type Not Found");
        }

        // Map the request to the entity
        TicketType ticketTypeEntity = mapper.Map<TicketType>(request.TicketType);

        try
        {
            // Update the lead Source
            _ticketTypeRepository.Update(ticketTypeEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Ticket Type updated successfully", ticketTypeEntity);
    }
}