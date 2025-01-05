using AvivCRM.Environment.Application.DTOs.BillOrders;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.UpdateBillOrder;
public record UpdateBillOrderCommand(UpdateBillOrderRequest BillOrder) : IRequest<ServerResponse>;
