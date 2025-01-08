#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.GetAllTax;
public record GetAllTaxQuery : IRequest<ServerResponse>;