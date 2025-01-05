using AvivCRM.Environment.Application.DTOs.BillOrders;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.CreateBillOrder;
public record CreateBillOrderCommand(CreateBillOrderRequest BillOrder) : IRequest<ServerResponse>;