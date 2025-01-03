using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Contracts.GetContractById;
public record GetContractByIdQuery(Guid Id) : IRequest<ServerResponse>;