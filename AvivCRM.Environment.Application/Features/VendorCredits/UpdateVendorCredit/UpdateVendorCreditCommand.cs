using AvivCRM.Environment.Application.DTOs.VendorCredit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.UpdateVendorCredit;
public record UpdateVendorCreditCommand(UpdateVendorCreditRequest VendorCredit) : IRequest<ServerResponse>;
