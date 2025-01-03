using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketChannels.CreateTicketChannel;

internal class CreateTicketChannelCommandHandler(IValidator<CreateTicketChannelRequest> validator,
    ITicketChannel _ticketChannelRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateTicketChannelCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateTicketChannelCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.TicketChannel);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var ticketChannelEntity = mapper.Map<TicketChannel>(request.TicketChannel);

        try
        {
            _ticketChannelRepository.Add(ticketChannelEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Ticket Channel Created Succcessfully", Data: ticketChannelEntity);
    }
}











