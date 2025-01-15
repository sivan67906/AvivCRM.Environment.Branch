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

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.Command.CreateFinancePrefixSetting;
internal class CreateFinancePrefixSettingCommandHandler(
    IValidator<CreateFinancePrefixSettingRequest> validator,
    IFinancePrefixSetting _financePrefixSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateFinancePrefixSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateFinancePrefixSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.FinancePrefixSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        FinancePrefixSetting financePrefixSettingEntity = mapper.Map<FinancePrefixSetting>(request.FinancePrefixSetting);

        try
        {
            _financePrefixSettingRepository.Add(financePrefixSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Finance Prefix Setting created successfully", financePrefixSettingEntity);
    }
}