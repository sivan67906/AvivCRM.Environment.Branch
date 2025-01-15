#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Clients.Query.GetAllClient;
public record GetAllClientQuery : IRequest<ServerResponse>;