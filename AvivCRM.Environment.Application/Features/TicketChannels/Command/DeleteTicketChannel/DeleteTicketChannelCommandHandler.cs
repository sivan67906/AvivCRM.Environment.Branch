#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketChannels.Command.DeleteTicketChannel;
internal class DeleteTicketChannelCommandHandler(
    ITicketChannel _ticketChannelRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteTicketChannelCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTicketChannelCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        TicketChannel? ticketChannel = await _ticketChannelRepository.GetByIdAsync(request.Id);
        if (ticketChannel is null)
        {
            return new ServerResponse(Message: "Ticket Channel Not Found");
        }

        // Map the request to the entity
        TicketChannel delMapEntity = mapper.Map<TicketChannel>(ticketChannel);

        try
        {
            // Delete plan type
            _ticketChannelRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Ticket Channel deleted successfully", delMapEntity);
    }
}