#region

using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.Command.UpdateCurrency;
public record UpdateCurrencyCommand(UpdateCurrencyRequest Currency) : IRequest<ServerResponse>;