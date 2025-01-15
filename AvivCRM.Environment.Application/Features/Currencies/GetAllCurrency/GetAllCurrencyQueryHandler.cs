#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.GetAllCurrency;
internal class GetAllCurrencyQueryHandler(ICurrency _currencyRepository, IMapper mapper)
    : IRequestHandler<GetAllCurrencyQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllCurrencyQuery request, CancellationToken cancellationToken)
    {
        // Get all Currency
        var currency = await _currencyRepository.GetAllAsync();
        if (currency is null)
        {
            return new ServerResponse(Message: "No Currency Found");
        }

        // Map the Currency to the response
        var currencyResponse = mapper.Map<IEnumerable<GetCurrency>>(currency);
        if (currencyResponse is null)
        {
            return new ServerResponse(Message: "Currency Not Found");
        }

        return new ServerResponse(true, "List of Currencies", currencyResponse);
    }
}