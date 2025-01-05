using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Applicationss.DeleteApplication;
public record DeleteApplicationCommand(Guid Id) : IRequest<ServerResponse>;
