﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.Query.GetAllContract;
internal class GetAllContractQueryHandler(IContract _contractRepository, IMapper mapper)
    : IRequestHandler<GetAllContractQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllContractQuery request, CancellationToken cancellationToken)
    {
        // Get all Contract
        IEnumerable<Domain.Entities.Contract>? contract = await _contractRepository.GetAllAsync();
        if (contract is null)
        {
            return new ServerResponse(Message: "No Contract Found");
        }

        // Map the Contract to the response
        IEnumerable<GetContract>? contractResponse = mapper.Map<IEnumerable<GetContract>>(contract);
        if (contractResponse is null)
        {
            return new ServerResponse(Message: "Contract Not Found");
        }

        return new ServerResponse(true, "List of Contracts", contractResponse);
    }
}