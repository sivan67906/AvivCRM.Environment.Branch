#region

using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.Command.CreateContract;
public record CreateContractCommand(CreateContractRequest Contract) : IRequest<ServerResponse>;