#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.TicketReplyTemplates.CreateTicketReplyTemplate;
internal class CreateTicketReplyTemplateCommandHandler(
    IValidator<CreateTicketReplyTemplateRequest> validator,
    ITicketReplyTemplate _ticketReplyTemplateRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateTicketReplyTemplateCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateTicketReplyTemplateCommand request,
        CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.TicketReplyTemplate);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var ticketReplyTemplateEntity = mapper.Map<TicketReplyTemplate>(request.TicketReplyTemplate);

        try
        {
            _ticketReplyTemplateRepository.Add(ticketReplyTemplateEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Ticket ReplyTemplate created successfully", ticketReplyTemplateEntity);
    }
}