#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.GetClientById;
public record GetClientByIdQuery(Guid Id) : IRequest<ServerResponse>;