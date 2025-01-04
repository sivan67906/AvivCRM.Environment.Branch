using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.UpdateTicketReplyTemplate;

internal class UpdateTicketReplyTemplateCommandHandler(IValidator<UpdateTicketReplyTemplateRequest> _validator, ITicketReplyTemplate _ticketReplyTemplateRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateTicketReplyTemplateCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTicketReplyTemplateCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.TicketReplyTemplate);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var ticketReplyTemplate = await _ticketReplyTemplateRepository.GetByIdAsync(request.TicketReplyTemplate.Id);
        if (ticketReplyTemplate is null) return new ServerResponse(Message: "Ticket ReplyTemplate Not Found");

        // Map the request to the entity
        var ticketReplyTemplateEntity = mapper.Map<TicketReplyTemplate>(request.TicketReplyTemplate);

        try
        {
            // Update the lead Source
            _ticketReplyTemplateRepository.Update(ticketReplyTemplateEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Ticket ReplyTemplate updated successfully", Data: ticketReplyTemplate);
    }
}









