using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.GetFinanceUnitSettingById;

internal class GetFinanceUnitSettingByIdQueryHandler(IFinanceUnitSetting financeUnitSettingRepository, IMapper mapper) : IRequestHandler<GetFinanceUnitSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetFinanceUnitSettingByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Finance Unit Setting by id
        var financeUnitSetting = await financeUnitSettingRepository.GetByIdAsync(request.Id);
        if (financeUnitSetting is null) return new ServerResponse(Message: "Finance Unit Setting Not Found");

        // Map the entity to the response
        var financeUnitSettingResponse = mapper.Map<GetFinanceUnitSetting>(financeUnitSetting); // <DTO> (parameter)
        if (financeUnitSettingResponse is null) return new ServerResponse(Message: "Finance Unit Setting Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Finance Unit Setting", Data: financeUnitSettingResponse);
    }
}









