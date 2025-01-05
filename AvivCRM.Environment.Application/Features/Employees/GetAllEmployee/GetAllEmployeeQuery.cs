using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Employees.GetAllEmployee;
public record GetAllEmployeeQuery : IRequest<ServerResponse>;