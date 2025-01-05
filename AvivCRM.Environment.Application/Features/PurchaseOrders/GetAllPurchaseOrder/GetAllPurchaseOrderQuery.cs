using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.PurchaseOrders.GetAllPurchaseOrder;
public record GetAllPurchaseOrderQuery : IRequest<ServerResponse>;
