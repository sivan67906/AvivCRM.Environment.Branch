#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.GetAllPayment;
public record GetAllPaymentQuery : IRequest<ServerResponse>;