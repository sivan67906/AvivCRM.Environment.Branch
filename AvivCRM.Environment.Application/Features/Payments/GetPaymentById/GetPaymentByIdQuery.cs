using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Payments.GetPaymentById;
public record GetPaymentByIdQuery(Guid Id) : IRequest<ServerResponse>;
