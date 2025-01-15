#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitGeneralSettings.Query.GetRecruitGeneralSettingById;
public record GetRecruitGeneralSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;