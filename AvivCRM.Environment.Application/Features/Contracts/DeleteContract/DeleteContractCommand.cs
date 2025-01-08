#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.DeleteContract;
public record DeleteContractCommand(Guid Id) : IRequest<ServerResponse>;