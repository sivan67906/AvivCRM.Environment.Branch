#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.GetFinancePrefixSettingById;
internal class GetFinancePrefixSettingByIdQueryHandler(
    IFinancePrefixSetting financePrefixSettingRepository,
    IMapper mapper) : IRequestHandler<GetFinancePrefixSettingByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetFinancePrefixSettingByIdQuery request,
        CancellationToken cancellationToken)
    {
        // Get the Finance Prefix Setting by id
        var financePrefixSetting = await financePrefixSettingRepository.GetByIdAsync(request.Id);
        if (financePrefixSetting is null)
        {
            return new ServerResponse(Message: "Finance Prefix Setting Not Found");
        }

        // Map the entity to the response
        var financePrefixSettingResponse =
            mapper.Map<GetFinancePrefixSetting>(financePrefixSetting); // <DTO> (parameter)
        if (financePrefixSettingResponse is null)
        {
            return new ServerResponse(Message: "Finance Prefix Setting Not Found");
        }

        return new ServerResponse(true, "List of Finance Prefix Setting", financePrefixSettingResponse);
    }
}