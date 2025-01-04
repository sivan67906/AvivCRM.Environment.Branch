using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Plannings.GetAllPlanning;
public record GetAllPlanningQuery : IRequest<ServerResponse>;
