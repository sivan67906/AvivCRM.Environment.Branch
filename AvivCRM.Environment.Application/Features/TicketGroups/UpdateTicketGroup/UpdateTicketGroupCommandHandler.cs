using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketGroups.UpdateTicketGroup;

internal class UpdateTicketGroupCommandHandler(IValidator<UpdateTicketGroupRequest> _validator, ITicketGroup _ticketGroupRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateTicketGroupCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTicketGroupCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.TicketGroup);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var ticketGroup = await _ticketGroupRepository.GetByIdAsync(request.TicketGroup.Id);
        if (ticketGroup is null) return new ServerResponse(Message: "Ticket Group Not Found");

        // Map the request to the entity
        var ticketGroupEntity = mapper.Map<TicketGroup>(request.TicketGroup);

        try
        {
            // Update the lead Source
            _ticketGroupRepository.Update(ticketGroupEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Ticket Group Updated Successfully", Data: ticketGroup);
    }
}









