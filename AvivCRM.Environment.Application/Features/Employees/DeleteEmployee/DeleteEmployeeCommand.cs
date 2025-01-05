using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Employees.DeleteEmployee;
public record DeleteEmployeeCommand(Guid Id) : IRequest<ServerResponse>;

