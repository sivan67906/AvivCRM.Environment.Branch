using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Currencies.DeleteCurrency;
public record DeleteCurrencyCommand(Guid Id) : IRequest<ServerResponse>;

