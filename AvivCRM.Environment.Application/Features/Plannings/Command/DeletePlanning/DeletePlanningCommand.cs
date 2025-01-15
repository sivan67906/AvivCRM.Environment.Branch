#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.Command.DeletePlanning;
public record DeletePlanningCommand(Guid Id) : IRequest<ServerResponse>;