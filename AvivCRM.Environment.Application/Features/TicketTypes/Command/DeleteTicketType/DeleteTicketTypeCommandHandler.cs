#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketTypes.Command.DeleteTicketType;
internal class DeleteTicketTypeCommandHandler(
    ITicketType _ticketTypeRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteTicketTypeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTicketTypeCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        TicketType? ticketType = await _ticketTypeRepository.GetByIdAsync(request.Id);
        if (ticketType is null)
        {
            return new ServerResponse(Message: "Ticket Type Not Found");
        }

        // Map the request to the entity
        TicketType delMapEntity = mapper.Map<TicketType>(ticketType);

        try
        {
            // Delete plan type
            _ticketTypeRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Ticket Type deleted successfully", delMapEntity);
    }
}