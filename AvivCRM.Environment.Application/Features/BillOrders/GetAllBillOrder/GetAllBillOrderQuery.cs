using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.BillOrders.GetAllBillOrder;
public record GetAllBillOrderQuery : IRequest<ServerResponse>;

