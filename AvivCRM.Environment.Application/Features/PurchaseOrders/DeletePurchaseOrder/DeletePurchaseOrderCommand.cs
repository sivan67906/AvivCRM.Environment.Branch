using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.DeletePurchaseOrder;
public record DeletePurchaseOrderCommand(Guid Id) : IRequest<ServerResponse>;
