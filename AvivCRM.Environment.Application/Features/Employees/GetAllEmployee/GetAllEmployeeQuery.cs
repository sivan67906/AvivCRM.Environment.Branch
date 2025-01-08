#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Employees.GetAllEmployee;
public record GetAllEmployeeQuery : IRequest<ServerResponse>;