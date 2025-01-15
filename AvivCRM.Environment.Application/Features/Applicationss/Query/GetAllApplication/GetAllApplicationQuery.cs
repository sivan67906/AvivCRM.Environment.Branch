#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Query.GetAllApplication;
public record GetAllApplicationQuery : IRequest<ServerResponse>;