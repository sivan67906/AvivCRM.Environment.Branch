using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Contracts.GetContractById;
internal class GetContractByIdQueryHandler(IContract contractRepository, IMapper mapper) : IRequestHandler<GetContractByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetContractByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Contract by id
        var contract = await contractRepository.GetByIdAsync(request.Id);
        if (contract is null) return new ServerResponse(Message: "Contract Not Found");

        // Map the entity to the response
        var contractResponse = mapper.Map<GetContract>(contract); // <DTO> (parameter)
        if (contractResponse is null) return new ServerResponse(Message: "Contract Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Contract", Data: contractResponse);
    }
}