#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.Query.GetEmployeeById;
public record GetEmployeeByIdQuery(Guid Id) : IRequest<ServerResponse>;