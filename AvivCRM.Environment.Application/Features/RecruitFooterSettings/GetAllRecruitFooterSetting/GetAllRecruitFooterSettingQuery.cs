#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitFooterSettings.GetAllRecruitFooterSetting;
public record GetAllRecruitFooterSettingQuery : IRequest<ServerResponse>;