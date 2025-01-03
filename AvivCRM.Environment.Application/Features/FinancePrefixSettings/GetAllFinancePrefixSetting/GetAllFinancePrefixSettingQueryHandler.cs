using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetAllFinancePrefixSetting;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetAllFinancePrefixSetting;
internal class GetAllFinancePrefixSettingQueryHandler(IFinancePrefixSetting _financePrefixSettingRepository, IMapper mapper) : IRequestHandler<GetAllFinancePrefixSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllFinancePrefixSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var financePrefixSetting = await _financePrefixSettingRepository.GetAllAsync();
        if (financePrefixSetting is null) return new ServerResponse(Message: "No Finance Prefix Setting Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetFinancePrefixSetting>>(financePrefixSetting);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Finance Prefix Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Finance Prefix Setting", Data: leadSourcResponse);
    }
}











