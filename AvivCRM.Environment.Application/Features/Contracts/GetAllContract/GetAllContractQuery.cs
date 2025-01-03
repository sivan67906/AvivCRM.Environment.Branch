using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Contracts.GetAllContract;
public record GetAllContractQuery : IRequest<ServerResponse>;