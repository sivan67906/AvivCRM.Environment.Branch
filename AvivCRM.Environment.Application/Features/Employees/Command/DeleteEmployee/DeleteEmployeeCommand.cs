#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.Command.DeleteEmployee;
public record DeleteEmployeeCommand(Guid Id) : IRequest<ServerResponse>;