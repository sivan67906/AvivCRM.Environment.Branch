#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.Query.GetAllFinancePrefixSetting;
internal class GetAllFinancePrefixSettingQueryHandler(
    IFinancePrefixSetting _financePrefixSettingRepository,
    IMapper mapper) : IRequestHandler<GetAllFinancePrefixSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllFinancePrefixSettingQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Finance.FinancePrefixSetting>? financePrefixSetting = await _financePrefixSettingRepository.GetAllAsync();
        if (financePrefixSetting is null)
        {
            return new ServerResponse(Message: "No Finance Prefix Setting Found");
        }

        // Map the plan types to the response
        IEnumerable<GetFinancePrefixSetting>? leadSourcResponse = mapper.Map<IEnumerable<GetFinancePrefixSetting>>(financePrefixSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Finance Prefix Setting Not Found");
        }

        return new ServerResponse(true, "List of Finance Prefix Settings", leadSourcResponse);
    }
}