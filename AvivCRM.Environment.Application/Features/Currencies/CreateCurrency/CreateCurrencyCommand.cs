#region

using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.CreateCurrency;
public record CreateCurrencyCommand(CreateCurrencyRequest Currency) : IRequest<ServerResponse>;