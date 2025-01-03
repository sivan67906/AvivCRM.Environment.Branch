using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.UpdateFinancePrefixSetting;

public record UpdateFinancePrefixSettingCommand(UpdateFinancePrefixSettingRequest FinancePrefixSetting) : IRequest<ServerResponse>;









