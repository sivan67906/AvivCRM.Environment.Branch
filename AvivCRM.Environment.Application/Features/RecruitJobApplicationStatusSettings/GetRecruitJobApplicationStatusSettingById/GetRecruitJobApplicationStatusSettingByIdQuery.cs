#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.
    GetRecruitJobApplicationStatusSettingById;
public record GetRecruitJobApplicationStatusSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;