using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.DeletePayment;
public record DeletePaymentCommand(Guid Id) : IRequest<ServerResponse>;

