#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.GetAllClient;
internal class GetAllClientQueryHandler(IClient _clientRepository, IMapper mapper)
    : IRequestHandler<GetAllClientQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
    {
        // Get all Contact
        var client = await _clientRepository.GetAllAsync();
        if (client is null)
        {
            return new ServerResponse(Message: "No Client Found");
        }

        // Map the Client to the response
        var clientResponse = mapper.Map<IEnumerable<GetClient>>(client);
        if (clientResponse is null)
        {
            return new ServerResponse(Message: "Client Not Found");
        }

        return new ServerResponse(true, "List of Clients", clientResponse);
    }
}