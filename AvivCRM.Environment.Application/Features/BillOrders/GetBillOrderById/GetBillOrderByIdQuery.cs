using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.GetBillOrderById;
public record GetBillOrderByIdQuery(Guid Id) : IRequest<ServerResponse>;