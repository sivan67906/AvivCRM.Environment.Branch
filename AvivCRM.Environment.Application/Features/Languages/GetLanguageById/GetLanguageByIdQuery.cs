using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Languages.GetLanguageById;
public record GetLanguageByIdQuery(Guid Id) : IRequest<ServerResponse>;
