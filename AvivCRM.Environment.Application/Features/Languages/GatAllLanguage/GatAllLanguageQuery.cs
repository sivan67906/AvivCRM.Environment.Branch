using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Languages.GatAllLanguage;
public record GetAllLanguagesQuery : IRequest<ServerResponse>;

