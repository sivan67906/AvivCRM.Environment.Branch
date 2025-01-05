using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Clients.GetAllClient;
public record GetAllClientQuery : IRequest<ServerResponse>;
