using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.GetPurchaseOrderById;
public record GetPurchaseOrderByIdQuery(Guid Id) : IRequest<ServerResponse>;