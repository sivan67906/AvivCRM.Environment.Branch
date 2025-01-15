#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.Query.GetAllLanguage;
public record GetAllLanguagesQuery : IRequest<ServerResponse>;