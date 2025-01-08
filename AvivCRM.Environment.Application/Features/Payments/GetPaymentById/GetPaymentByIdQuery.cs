#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.GetPaymentById;
public record GetPaymentByIdQuery(Guid Id) : IRequest<ServerResponse>;