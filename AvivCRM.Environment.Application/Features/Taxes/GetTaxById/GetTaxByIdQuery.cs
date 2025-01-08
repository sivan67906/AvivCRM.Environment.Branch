#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.GetTaxById;
public record GetTaxByIdQuery(Guid Id) : IRequest<ServerResponse>;