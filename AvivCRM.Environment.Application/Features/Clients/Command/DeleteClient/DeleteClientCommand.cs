#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.Command.DeleteClient;
public record DeleteClientCommand(Guid Id) : IRequest<ServerResponse>;