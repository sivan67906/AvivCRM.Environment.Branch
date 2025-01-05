using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.GetAllVendorCredit;
public record GetAllVendorCreditQuery : IRequest<ServerResponse>;
