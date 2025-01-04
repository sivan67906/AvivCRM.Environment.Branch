using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Taxes.DeleteTax;
public record DeleteTaxCommand(Guid Id) : IRequest<ServerResponse>;
