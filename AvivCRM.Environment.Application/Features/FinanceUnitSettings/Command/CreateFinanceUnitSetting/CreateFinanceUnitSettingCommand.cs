#region

using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.CreateFinanceUnitSetting;
public record CreateFinanceUnitSettingCommand(CreateFinanceUnitSettingRequest FinanceUnitSetting)
    : IRequest<ServerResponse>;