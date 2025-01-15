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

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.Command.CreateFinanceUnitSetting;
internal class CreateFinanceUnitSettingCommandHandler(
    IValidator<CreateFinanceUnitSettingRequest> validator,
    IFinanceUnitSetting _financeUnitSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateFinanceUnitSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateFinanceUnitSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.FinanceUnitSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        FinanceUnitSetting financeUnitSettingEntity = mapper.Map<FinanceUnitSetting>(request.FinanceUnitSetting);

        try
        {
            _financeUnitSettingRepository.Add(financeUnitSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Finance Unit Setting created successfully", financeUnitSettingEntity);
    }
}