#region

using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.CreateLanguage;
public record CreateLanguageCommand(createLanguageRequest Language) : IRequest<ServerResponse>;