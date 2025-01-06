using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Languages.DeleteLanguage;
public record DeleteLanguageCommand(Guid Id) : IRequest<ServerResponse>;

