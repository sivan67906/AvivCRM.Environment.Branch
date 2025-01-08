#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.GetClientById;
internal class GetClientByIdQueryHandler(IClient clientRepository, IMapper mapper)
    : IRequestHandler<GetClientByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Client by id
        var client = await clientRepository.GetByIdAsync(request.Id);
        if (client is null)
        {
            return new ServerResponse(Message: "Client Not Found");
        }

        // Map the entity to the response
        var clientResponse = mapper.Map<GetClient>(client); // <DTO> (parameter)
        if (clientResponse is null)
        {
            return new ServerResponse(Message: "Client Not Found");
        }

        return new ServerResponse(true, "List of Client", clientResponse);
    }
}