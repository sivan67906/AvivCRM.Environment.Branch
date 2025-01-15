#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.Query.GetClientById;
public record GetClientByIdQuery(Guid Id) : IRequest<ServerResponse>;