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

namespace AvivCRM.Environment.Application.Features.PurchaseSettings.Command.CreatePurchaseSetting;
internal class CreatePurchaseSettingCommandHandler(
    IValidator<CreatePurchaseSettingRequest> validator,
    IPurchaseSetting _purchaseSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreatePurchaseSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreatePurchaseSettingCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.PurchaseSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        PurchaseSetting purchaseSettingEntity = mapper.Map<PurchaseSetting>(request.PurchaseSetting);

        try
        {
            _purchaseSettingRepository.Add(purchaseSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Purchase Setting created successfully", purchaseSettingEntity);
    }
}