using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.GetVendorCreditById;
public record GetVendorCreditByIdQuery(Guid Id) : IRequest<ServerResponse>;