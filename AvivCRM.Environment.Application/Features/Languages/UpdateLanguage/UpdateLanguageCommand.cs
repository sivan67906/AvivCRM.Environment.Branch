using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Languages.UpdateLanguage;
public record UpdateLanguageCommand(UpdateLanguageRequest Language) : IRequest<ServerResponse>;

