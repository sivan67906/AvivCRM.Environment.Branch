#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.DeletePayment;
public record DeletePaymentCommand(Guid Id) : IRequest<ServerResponse>;