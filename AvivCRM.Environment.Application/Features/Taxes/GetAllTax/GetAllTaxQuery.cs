using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taxes.GetAllTax;
public record GetAllTaxQuery : IRequest<ServerResponse>;

