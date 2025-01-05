using AvivCRM.Environment.Application.DTOs.VendorCredit;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.VendorCredits.CreateVendorCredit;
public record CreateVendorCreditCommand(CreateVendorCreditRequest VendorCredit) : IRequest<ServerResponse>;