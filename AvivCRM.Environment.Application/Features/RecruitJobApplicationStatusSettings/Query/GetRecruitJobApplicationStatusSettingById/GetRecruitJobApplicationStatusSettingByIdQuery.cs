#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.Query.GetRecruitJobApplicationStatusSettingById;
public record GetRecruitJobApplicationStatusSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;