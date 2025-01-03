using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketChannels.UpdateTicketChannel;

internal class UpdateTicketChannelCommandHandler(IValidator<UpdateTicketChannelRequest> _validator, ITicketChannel _ticketChannelRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateTicketChannelCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTicketChannelCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.TicketChannel);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var ticketChannel = await _ticketChannelRepository.GetByIdAsync(request.TicketChannel.Id);
        if (ticketChannel is null) return new ServerResponse(Message: "Ticket Channel Not Found");

        // Map the request to the entity
        var ticketChannelEntity = mapper.Map<TicketChannel>(request.TicketChannel);

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

        return new ServerResponse(IsSuccess: true, Message: "Ticket Channel Updated Successfully", Data: ticketChannel);
    }
}









