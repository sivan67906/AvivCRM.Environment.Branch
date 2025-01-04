using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Plannings.CreatePlanning;
public record CreatePlanningCommand(CreatePlanningRequest Planning) : IRequest<ServerResponse>;
