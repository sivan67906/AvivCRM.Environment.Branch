using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Clients.DeleteClient;
public record DeleteClientCommand(Guid Id) : IRequest<ServerResponse>;

