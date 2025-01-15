#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Languages.Query.GetLanguageById;
public record GetLanguageByIdQuery(Guid Id) : IRequest<ServerResponse>;