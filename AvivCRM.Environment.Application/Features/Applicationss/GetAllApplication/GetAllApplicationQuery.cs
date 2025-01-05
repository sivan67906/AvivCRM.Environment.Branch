using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Applicationss.GetAllApplication;
public record GetAllApplicationQuery : IRequest<ServerResponse>;
