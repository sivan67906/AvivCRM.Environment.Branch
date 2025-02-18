#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.UpdateFinanceUnitSetting;
internal class UpdateFinanceUnitSettingCommandHandler(
    IValidator<UpdateFinanceUnitSettingRequest> _validator,
    IFinanceUnitSetting _financeUnitSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateFinanceUnitSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateFinanceUnitSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.FinanceUnitSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        FinanceUnitSetting? financeUnitSetting = await _financeUnitSettingRepository.GetByIdAsync(request.FinanceUnitSetting.Id);
        if (financeUnitSetting is null)
        {
            return new ServerResponse(Message: "Finance Unit Setting Not Found");
        }

        // Map the request to the entity
        FinanceUnitSetting financeUnitSettingEntity = mapper.Map<FinanceUnitSetting>(request.FinanceUnitSetting);

        try
        {
            // Update the lead Source
            _financeUnitSettingRepository.Update(financeUnitSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Finance Unit Setting updated successfully", financeUnitSettingEntity);
    }
}