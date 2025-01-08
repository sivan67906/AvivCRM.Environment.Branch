#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.DeletePlanning;
public record DeletePlanningCommand(Guid Id) : IRequest<ServerResponse>;