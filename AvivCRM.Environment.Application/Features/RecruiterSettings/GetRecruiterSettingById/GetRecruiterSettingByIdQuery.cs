#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.GetRecruiterSettingById;
public record GetRecruiterSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;