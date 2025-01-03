using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceUnitSettings.CreateFinanceUnitSetting;

internal class CreateFinanceUnitSettingCommandHandler(IValidator<CreateFinanceUnitSettingRequest> validator,
    IFinanceUnitSetting _financeUnitSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateFinanceUnitSettingCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateFinanceUnitSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.FinanceUnitSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var financeUnitSettingEntity = mapper.Map<FinanceUnitSetting>(request.FinanceUnitSetting);

        try
        {
            _financeUnitSettingRepository.Add(financeUnitSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Finance Unit Setting Created Succcessfully", Data: financeUnitSettingEntity);
    }
}











