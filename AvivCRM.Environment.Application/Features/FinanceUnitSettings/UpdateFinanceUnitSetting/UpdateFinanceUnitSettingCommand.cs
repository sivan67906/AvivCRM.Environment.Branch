using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.UpdateFinanceUnitSetting;

public record UpdateFinanceUnitSettingCommand(UpdateFinanceUnitSettingRequest FinanceUnitSetting) : IRequest<ServerResponse>;









