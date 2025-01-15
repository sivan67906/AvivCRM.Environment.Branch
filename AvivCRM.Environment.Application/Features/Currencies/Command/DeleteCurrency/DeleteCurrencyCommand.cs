#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.Command.DeleteCurrency;
public record DeleteCurrencyCommand(Guid Id) : IRequest<ServerResponse>;