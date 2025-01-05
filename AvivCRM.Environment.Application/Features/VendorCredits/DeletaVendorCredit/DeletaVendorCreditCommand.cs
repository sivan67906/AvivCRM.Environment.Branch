using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.DeletaVendorCredit;
public record DeleteVendorCreditCommand(Guid Id) : IRequest<ServerResponse>;
