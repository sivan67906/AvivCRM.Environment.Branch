using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.UpdatePurchaseOrder;
public record UpdatePurchaseOrderCommand(UpdatePurchaseOrderRequest PurchaseOrder) : IRequest<ServerResponse>;
