#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.Command.UpdateClient;
internal class UpdateClientCommandHandler(
    IValidator<UpdateClientRequest> _validator,
    IClient _clientRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateClientCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Client);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Client exists
        Client? client = await _clientRepository.GetByIdAsync(request.Client.Id);
        if (client is null)
        {
            return new ServerResponse(Message: "Client Not Found");
        }

        // Map the request to the entity
        Client clientEntity = mapper.Map<Client>(request.Client);

        try
        {
            // Update the Client
            _clientRepository.Update(clientEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Client updated successfully", clientEntity);
    }
}