#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Payments.Query.GetPaymentById;
public record GetPaymentByIdQuery(Guid Id) : IRequest<ServerResponse>;