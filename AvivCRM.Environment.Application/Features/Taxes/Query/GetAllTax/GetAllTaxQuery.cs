#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.Query.GetAllTax;
public record GetAllTaxQuery : IRequest<ServerResponse>;