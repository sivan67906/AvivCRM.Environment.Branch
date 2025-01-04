using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.DeleteFinanceUnitSetting;

internal class DeleteFinanceUnitSettingCommandHandler(IFinanceUnitSetting _financeUnitSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteFinanceUnitSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteFinanceUnitSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var financeUnitSetting = await _financeUnitSettingRepository.GetByIdAsync(request.Id);
        if (financeUnitSetting is null) return new ServerResponse(Message: "Finance Unit Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<FinanceUnitSetting>(financeUnitSetting);

        try
        {
            // Delete plan type
            _financeUnitSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Finance Unit Setting deleted successfully", Data: financeUnitSetting);
    }
}











