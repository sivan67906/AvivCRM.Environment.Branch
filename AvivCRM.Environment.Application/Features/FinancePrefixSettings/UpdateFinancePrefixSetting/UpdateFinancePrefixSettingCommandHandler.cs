using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.UpdateFinancePrefixSetting;

internal class UpdateFinancePrefixSettingCommandHandler(IValidator<UpdateFinancePrefixSettingRequest> _validator, IFinancePrefixSetting _financePrefixSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateFinancePrefixSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateFinancePrefixSettingCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.FinancePrefixSetting);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var financePrefixSetting = await _financePrefixSettingRepository.GetByIdAsync(request.FinancePrefixSetting.Id);
        if (financePrefixSetting is null) return new ServerResponse(Message: "Finance Prefix Setting Not Found");

        // Map the request to the entity
        var financePrefixSettingEntity = mapper.Map<FinancePrefixSetting>(request.FinancePrefixSetting);

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

        return new ServerResponse(IsSuccess: true, Message: "Finance Prefix Setting updated successfully", Data: financePrefixSetting);
    }
}









