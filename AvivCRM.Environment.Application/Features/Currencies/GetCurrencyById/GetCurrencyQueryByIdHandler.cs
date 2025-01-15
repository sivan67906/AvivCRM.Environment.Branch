﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.GetCurrencyById;
internal class GetCurrencyByIdQueryHandler(ICurrency currencyRepository, IMapper mapper)
    : IRequestHandler<GetCurrencyByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Currency by id
        var currency = await currencyRepository.GetByIdAsync(request.Id);
        if (currency is null)
        {
            return new ServerResponse(Message: "Currency Not Found");
        }

        // Map the entity to the response
        var currencyResponse = mapper.Map<GetCurrency>(currency); // <DTO> (parameter)
        if (currencyResponse is null)
        {
            return new ServerResponse(Message: "Currency Not Found");
        }

        return new ServerResponse(true, "List of Currency", currencyResponse);
    }
}