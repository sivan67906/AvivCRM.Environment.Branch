#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.Command.DeleteClient;
internal class DeleteClientCommandHandler(IClient _clientRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteClientCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        Client? client = await _clientRepository.GetByIdAsync(request.Id);
        if (client is null)
        {
            return new ServerResponse(Message: "Client Not Found");
        }

        // Map the request to the entity
        Client delMapEntity = mapper.Map<Client>(client);

        try
        {
            // Delete Client
            _clientRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Client deleted successfully", delMapEntity);
    }
}