using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.CreateFinanceUnitSetting;

public record CreateFinanceUnitSettingCommand(CreateFinanceUnitSettingRequest FinanceUnitSetting) : IRequest<ServerResponse>;









