#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.Query.GetContractById;
public record GetContractByIdQuery(Guid Id) : IRequest<ServerResponse>;