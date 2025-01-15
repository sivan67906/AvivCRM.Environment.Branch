#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.Command.DeleteFinancePrefixSetting;
internal class DeleteFinancePrefixSettingCommandHandler(
    IFinancePrefixSetting _financePrefixSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteFinancePrefixSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteFinancePrefixSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        FinancePrefixSetting? financePrefixSetting = await _financePrefixSettingRepository.GetByIdAsync(request.Id);
        if (financePrefixSetting is null)
        {
            return new ServerResponse(Message: "Finance Prefix Setting Not Found");
        }

        // Map the request to the entity
        FinancePrefixSetting delMapEntity = mapper.Map<FinancePrefixSetting>(financePrefixSetting);

        try
        {
            // Delete plan type
            _financePrefixSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Finance Prefix Setting deleted successfully", financePrefixSetting);
    }
}