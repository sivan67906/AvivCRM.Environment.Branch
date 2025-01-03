using AutoMapper;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Ticket;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.TicketTypes.CreateTicketType;

internal class CreateTicketTypeCommandHandler(IValidator<CreateTicketTypeRequest> validator,
    ITicketType _ticketTypeRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateTicketTypeCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.TicketType);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var ticketTypeEntity = mapper.Map<TicketType>(request.TicketType);

        try
        {
            _ticketTypeRepository.Add(ticketTypeEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Ticket Type Created Succcessfully", Data: ticketTypeEntity);
    }
}











