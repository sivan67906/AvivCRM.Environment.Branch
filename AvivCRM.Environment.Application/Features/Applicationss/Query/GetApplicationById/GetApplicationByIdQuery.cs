#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Query.GetApplicationById;
public record GetApplicationByIdQuery(Guid Id) : IRequest<ServerResponse>;