using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Currencies.GetCurrencyById;
public record GetCurrencyByIdQuery(Guid Id) : IRequest<ServerResponse>;
