#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.Command.UpdateFinancePrefixSetting;
internal class UpdateFinancePrefixSettingCommandHandler(
    IValidator<UpdateFinancePrefixSettingRequest> _validator,
    IFinancePrefixSetting _financePrefixSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateFinancePrefixSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateFinancePrefixSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.FinancePrefixSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        FinancePrefixSetting? financePrefixSetting = await _financePrefixSettingRepository.GetByIdAsync(request.FinancePrefixSetting.Id);
        if (financePrefixSetting is null)
        {
            return new ServerResponse(Message: "Finance Prefix Setting Not Found");
        }

        // Map the request to the entity
        FinancePrefixSetting financePrefixSettingEntity = mapper.Map<FinancePrefixSetting>(request.FinancePrefixSetting);

        try
        {
            // Update the lead Source
            _financePrefixSettingRepository.Update(financePrefixSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Finance Prefix Setting updated successfully", financePrefixSetting);
    }
}