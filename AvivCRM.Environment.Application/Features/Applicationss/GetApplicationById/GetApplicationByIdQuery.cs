using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Applicationss.GetApplicationById;
public record GetApplicationByIdQuery(Guid Id) : IRequest<ServerResponse>;