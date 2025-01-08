#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetAllFinanceUnitSetting;
public record GetAllFinanceUnitSettingQuery : IRequest<ServerResponse>;