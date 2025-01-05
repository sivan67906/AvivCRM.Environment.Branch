using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taxes.UpdateTax;
public record UpdateTaxCommand(UpdateTaxRequest Tax) : IRequest<ServerResponse>;
