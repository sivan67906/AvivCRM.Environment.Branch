using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taxes.GetTaxById;
public record GetTaxByIdQuery(Guid Id) : IRequest<ServerResponse>;
