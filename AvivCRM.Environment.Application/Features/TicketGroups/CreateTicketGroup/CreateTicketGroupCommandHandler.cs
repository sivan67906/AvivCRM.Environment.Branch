#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketGroups.CreateTicketGroup;
internal class CreateTicketGroupCommandHandler(
    IValidator<CreateTicketGroupRequest> validator,
    ITicketGroup _ticketGroupRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateTicketGroupCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateTicketGroupCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.TicketGroup);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var ticketGroupEntity = mapper.Map<TicketGroup>(request.TicketGroup);

        try
        {
            _ticketGroupRepository.Add(ticketGroupEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Ticket Group created successfully", ticketGroupEntity);
    }
}