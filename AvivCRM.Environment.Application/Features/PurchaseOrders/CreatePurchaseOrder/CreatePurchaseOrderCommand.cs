using AvivCRM.Environment.Application.DTOs.PurchaseOrders;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.CreatePurchaseOrder;
public record CreatePurchaseOrderCommand(CreatePurchaseOrderRequest PurchaseOrder) : IRequest<ServerResponse>;