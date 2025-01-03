using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinancePrefixSettings.CreateFinancePrefixSetting;

internal class CreateFinancePrefixSettingCommandHandler(IValidator<CreateFinancePrefixSettingRequest> validator,
    IFinancePrefixSetting _financePrefixSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateFinancePrefixSettingCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateFinancePrefixSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.FinancePrefixSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var financePrefixSettingEntity = mapper.Map<FinancePrefixSetting>(request.FinancePrefixSetting);

        try
        {
            _financePrefixSettingRepository.Add(financePrefixSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Finance Prefix Setting Created Succcessfully", Data: financePrefixSettingEntity);
    }
}











