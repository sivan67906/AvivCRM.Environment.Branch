#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Query.GetAllFinanceUnitSetting;
internal class GetAllFinanceUnitSettingQueryHandler(IFinanceUnitSetting _financeUnitSettingRepository, IMapper mapper)
    : IRequestHandler<GetAllFinanceUnitSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllFinanceUnitSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        IEnumerable<Domain.Entities.Finance.FinanceUnitSetting>? financeUnitSetting = await _financeUnitSettingRepository.GetAllAsync();
        if (financeUnitSetting is null)
        {
            return new ServerResponse(Message: "No Finance Unit Setting Found");
        }

        // Map the plan types to the response
        IEnumerable<GetFinanceUnitSetting>? leadSourcResponse = mapper.Map<IEnumerable<GetFinanceUnitSetting>>(financeUnitSetting);
        if (leadSourcResponse is null)
        {
            return new ServerResponse(Message: "Finance Unit Setting Not Found");
        }

        return new ServerResponse(true, "List of Finance Unit Settings", leadSourcResponse);
    }
}