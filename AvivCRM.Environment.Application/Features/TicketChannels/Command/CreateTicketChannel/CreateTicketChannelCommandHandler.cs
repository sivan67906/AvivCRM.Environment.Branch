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

namespace AvivCRM.Environment.Application.Features.TicketChannels.Command.CreateTicketChannel;
internal class CreateTicketChannelCommandHandler(
    IValidator<CreateTicketChannelRequest> validator,
    ITicketChannel _ticketChannelRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateTicketChannelCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateTicketChannelCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.TicketChannel);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        TicketChannel ticketChannelEntity = mapper.Map<TicketChannel>(request.TicketChannel);

        try
        {
            _ticketChannelRepository.Add(ticketChannelEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Ticket Channel created successfully", ticketChannelEntity);
    }
}