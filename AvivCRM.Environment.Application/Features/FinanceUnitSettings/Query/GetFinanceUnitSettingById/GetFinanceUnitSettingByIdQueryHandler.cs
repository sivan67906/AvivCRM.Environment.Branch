#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Query.GetFinanceUnitSettingById;
internal class GetFinanceUnitSettingByIdQueryHandler(IFinanceUnitSetting financeUnitSettingRepository, IMapper mapper)
    : IRequestHandler<GetFinanceUnitSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetFinanceUnitSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Finance Unit Setting by id
        Domain.Entities.Finance.FinanceUnitSetting? financeUnitSetting = await financeUnitSettingRepository.GetByIdAsync(request.Id);
        if (financeUnitSetting is null)
        {
            return new ServerResponse(Message: "Finance Unit Setting Not Found");
        }

        // Map the entity to the response
        GetFinanceUnitSetting? financeUnitSettingResponse = mapper.Map<GetFinanceUnitSetting>(financeUnitSetting); // <DTO> (parameter)
        if (financeUnitSettingResponse is null)
        {
            return new ServerResponse(Message: "Finance Unit Setting Not Found");
        }

        return new ServerResponse(true, "List of Finance Unit Setting", financeUnitSettingResponse);
    }
}