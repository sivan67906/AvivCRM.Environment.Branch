using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.UpdatePayment;
public record UpdatePaymentCommand(UpdatePaymentRequest Payment) : IRequest<ServerResponse>;
