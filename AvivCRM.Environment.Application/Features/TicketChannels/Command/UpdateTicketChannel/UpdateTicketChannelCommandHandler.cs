#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Command.UpdateTicketChannel;
internal class UpdateTicketChannelCommandHandler(
    IValidator<UpdateTicketChannelRequest> _validator,
    ITicketChannel _ticketChannelRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateTicketChannelCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTicketChannelCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.TicketChannel);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        TicketChannel? ticketChannel = await _ticketChannelRepository.GetByIdAsync(request.TicketChannel.Id);
        if (ticketChannel is null)
        {
            return new ServerResponse(Message: "Ticket Channel Not Found");
        }

        // Map the request to the entity
        TicketChannel ticketChannelEntity = mapper.Map<TicketChannel>(request.TicketChannel);

        try
        {
            // Update the lead Source
            _ticketChannelRepository.Update(ticketChannelEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Ticket Channel updated successfully", ticketChannelEntity);
    }
}