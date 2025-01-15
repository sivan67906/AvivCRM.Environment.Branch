#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Purchase;
using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.Command.UpdatePurchaseSetting;
internal class UpdatePurchaseSettingCommandHandler(
    IValidator<UpdatePurchaseSettingRequest> _validator,
    IPurchaseSetting _purchaseSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdatePurchaseSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdatePurchaseSettingCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.PurchaseSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the purchase Setting exists
        PurchaseSetting? purchaseSetting = await _purchaseSettingRepository.GetByIdAsync(request.PurchaseSetting.Id);
        if (purchaseSetting is null)
        {
            return new ServerResponse(Message: "Purchase Setting Not Found");
        }

        // Map the request to the entity
        PurchaseSetting purchaseSettingEntity = mapper.Map<PurchaseSetting>(request.PurchaseSetting);

        try
        {
            // Update the purchase Setting
            _purchaseSettingRepository.Update(purchaseSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Purchase Setting updated successfully", purchaseSettingEntity);
    }
}