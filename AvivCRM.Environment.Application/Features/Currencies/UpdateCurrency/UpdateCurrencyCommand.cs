#region

using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.UpdateCurrency;
public record UpdateCurrencyCommand(UpdateCurrencyRequest Currency) : IRequest<ServerResponse>;