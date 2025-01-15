#region

using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Query.GetAllFinanceUnitSetting;
public record GetAllFinanceUnitSettingQuery : IRequest<ServerResponse>;