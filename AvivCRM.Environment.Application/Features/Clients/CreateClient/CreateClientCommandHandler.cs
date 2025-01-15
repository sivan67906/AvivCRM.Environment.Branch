#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.CreateClient;
internal class CreateClientCommandHandler(
    IValidator<CreateClientRequest> _validator,
    IClient _clientRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreateClientCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.Client);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }


        // Map the request to the entity
        var clientEntity = mapper.Map<Client>(request.Client);

        try
        {
            // Add the client
            _clientRepository.Add(clientEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Client created successfully", clientEntity);
    }
}