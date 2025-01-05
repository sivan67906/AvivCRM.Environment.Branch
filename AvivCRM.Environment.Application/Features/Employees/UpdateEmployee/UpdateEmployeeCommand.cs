using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Employees.UpdateEmployee;
public record UpdateEmployeeCommand(UpdateEmployeeRequest Employee) : IRequest<ServerResponse>;
