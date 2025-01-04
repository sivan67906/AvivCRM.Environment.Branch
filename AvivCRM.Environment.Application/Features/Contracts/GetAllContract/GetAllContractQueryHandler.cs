using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Contracts.GetAllContract;
internal class GetAllContractQueryHandler(IContract _contractRepository, IMapper mapper) : IRequestHandler<GetAllContractQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllContractQuery request, CancellationToken cancellationToken)
    {
        // Get all Contract
        var contract = await _contractRepository.GetAllAsync();
        if (contract is null) return new ServerResponse(Message: "No Contract Found");

        // Map the Contract to the response
        var contractResponse = mapper.Map<IEnumerable<GetContract>>(contract);
        if (contractResponse is null) return new ServerResponse(Message: "Contract Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Contracts", Data: contractResponse);
    }
}