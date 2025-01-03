using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetAllFinanceUnitSetting;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetAllFinanceUnitSetting;
internal class GetAllFinanceUnitSettingQueryHandler(IFinanceUnitSetting _financeUnitSettingRepository, IMapper mapper) : IRequestHandler<GetAllFinanceUnitSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllFinanceUnitSettingQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var financeUnitSetting = await _financeUnitSettingRepository.GetAllAsync();
        if (financeUnitSetting is null) return new ServerResponse(Message: "No Finance Unit Setting Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetFinanceUnitSetting>>(financeUnitSetting);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Finance Unit Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Finance Unit Setting", Data: leadSourcResponse);
    }
}











