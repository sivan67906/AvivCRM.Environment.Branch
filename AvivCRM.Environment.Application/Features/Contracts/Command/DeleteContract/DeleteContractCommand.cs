#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.Command.DeleteContract;
public record DeleteContractCommand(Guid Id) : IRequest<ServerResponse>;