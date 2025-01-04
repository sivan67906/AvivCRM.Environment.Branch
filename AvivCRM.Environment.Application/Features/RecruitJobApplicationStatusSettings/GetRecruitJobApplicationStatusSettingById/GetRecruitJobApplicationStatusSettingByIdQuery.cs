using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.RecruitJobApplicationStatusSettings.GetRecruitJobApplicationStatusSettingById;

public record GetRecruitJobApplicationStatusSettingByIdQuery(Guid Id) : IRequest<ServerResponse>;









