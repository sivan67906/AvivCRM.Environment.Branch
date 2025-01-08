using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketGroups.DeleteTicketGroup;

internal class DeleteTicketGroupCommandHandler(ITicketGroup _ticketGroupRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteTicketGroupCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteTicketGroupCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var ticketGroup = await _ticketGroupRepository.GetByIdAsync(request.Id);
        if (ticketGroup is null) return new ServerResponse(Message: "Ticket Group Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<TicketGroup>(ticketGroup);

        try
        {
            // Delete plan type
            _ticketGroupRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Ticket Group deleted successfully", Data: delMapEntity);
    }
}











