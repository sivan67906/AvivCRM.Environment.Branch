#region

using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.Command.UpdateClient;
public record UpdateClientCommand(UpdateClientRequest Client) : IRequest<ServerResponse>;