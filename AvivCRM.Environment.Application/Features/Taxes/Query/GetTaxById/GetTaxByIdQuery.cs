#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.Query.GetTaxById;
public record GetTaxByIdQuery(Guid Id) : IRequest<ServerResponse>;