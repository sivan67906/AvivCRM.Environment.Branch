using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.GetAllPayment;
public record GetAllPaymentQuery : IRequest<ServerResponse>;

