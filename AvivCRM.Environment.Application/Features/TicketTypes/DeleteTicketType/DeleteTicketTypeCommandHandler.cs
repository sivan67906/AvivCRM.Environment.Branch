using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketTypes.DeleteTicketType;

internal class DeleteTicketTypeCommandHandler(ITicketType _ticketTypeRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteTicketTypeCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTicketTypeCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var ticketType = await _ticketTypeRepository.GetByIdAsync(request.Id);
        if (ticketType is null) return new ServerResponse(Message: "Ticket Type Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<TicketType>(ticketType);

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

        return new ServerResponse(IsSuccess: true, Message: "Ticket Type deleted successfully", Data: delMapEntity);
    }
}











