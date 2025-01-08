#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.DeleteTax;
public record DeleteTaxCommand(Guid Id) : IRequest<ServerResponse>;