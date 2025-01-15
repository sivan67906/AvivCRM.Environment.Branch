#region

using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.Command.UpdateTax;
public record UpdateTaxCommand(UpdateTaxRequest Tax) : IRequest<ServerResponse>;