#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruiterSettings.Query.GetAllRecruiterSetting;
public record GetAllRecruiterSettingQuery : IRequest<ServerResponse>;