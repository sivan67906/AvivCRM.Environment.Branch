using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.DeleteBillOrder;
public record DeleteBillOrderCommand(Guid Id) : IRequest<ServerResponse>;
