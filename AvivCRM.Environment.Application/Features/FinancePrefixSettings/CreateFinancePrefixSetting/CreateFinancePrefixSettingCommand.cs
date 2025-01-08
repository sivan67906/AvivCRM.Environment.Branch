#region

using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.CreateFinancePrefixSetting;
public record CreateFinancePrefixSettingCommand(CreateFinancePrefixSettingRequest FinancePrefixSetting)
    : IRequest<ServerResponse>;