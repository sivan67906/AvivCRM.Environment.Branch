#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.CreateFinanceInvoiceSetting;
internal class CreateFinanceInvoiceSettingCommandHandler(
    IValidator<CreateFinanceInvoiceSettingRequest> validator,
    IFinanceInvoiceSetting _financeInvoiceSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateFinanceInvoiceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateFinanceInvoiceSettingCommand request,
        CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.FinanceInvoiceSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var financeInvoiceSettingEntity = mapper.Map<FinanceInvoiceSetting>(request.FinanceInvoiceSetting);

        try
        {
            _financeInvoiceSettingRepository.Add(financeInvoiceSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Finance Invoice Setting created successfully", financeInvoiceSettingEntity);
    }
}