#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.DeletePurchaseSetting;
internal class DeletePurchaseSettingCommandHandler(
    IPurchaseSetting _purchaseSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeletePurchaseSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeletePurchaseSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var purchaseSetting = await _purchaseSettingRepository.GetByIdAsync(request.Id);
        if (purchaseSetting is null)
        {
            return new ServerResponse(Message: "Purchase Setting Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<PurchaseSetting>(purchaseSetting);

        try
        {
            // Delete Purchase Setting
            _purchaseSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Purchase Setting deleted successfully", delMapEntity);
    }
}