#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.Query.GetCurrencyById;
public record GetCurrencyByIdQuery(Guid Id) : IRequest<ServerResponse>;