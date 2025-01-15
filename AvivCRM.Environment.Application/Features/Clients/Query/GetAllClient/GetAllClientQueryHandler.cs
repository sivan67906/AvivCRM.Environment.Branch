#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.Query.GetAllClient;
internal class GetAllClientQueryHandler(IClient _clientRepository, IMapper mapper)
    : IRequestHandler<GetAllClientQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        IEnumerable<Domain.Entities.Client>? client = await _clientRepository.GetAllAsync();
        if (client is null)
        {
            return new ServerResponse(Message: "No Client Found");
        }

        // Map the Client to the response
        IEnumerable<GetClient>? clientResponse = mapper.Map<IEnumerable<GetClient>>(client);
        if (clientResponse is null)
        {
            return new ServerResponse(Message: "Client Not Found");
        }

        return new ServerResponse(true, "List of Clients", clientResponse);
    }
}