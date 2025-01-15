#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.Command.UpdateFinanceInvoiceSetting;
internal class UpdateFinanceInvoiceSettingCommandHandler(
    IValidator<UpdateFinanceInvoiceSettingRequest> _validator,
    IFinanceInvoiceSetting _financeInvoiceSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateFinanceInvoiceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateFinanceInvoiceSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.FinanceInvoiceSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the FinanceInvoiceSetting exists
        FinanceInvoiceSetting? financeInvoiceSetting =
            await _financeInvoiceSettingRepository.GetByIdAsync(request.FinanceInvoiceSetting.Id);
        if (financeInvoiceSetting is null)
        {
            return new ServerResponse(Message: "FinanceInvoiceSetting Not Found");
        }

        // Map the request to the entity
        FinanceInvoiceSetting financeInvoiceSettingEntity = mapper.Map<FinanceInvoiceSetting>(request.FinanceInvoiceSetting);

        try
        {
            // Update the FinanceInvoiceSetting
            _financeInvoiceSettingRepository.Update(financeInvoiceSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "FinanceInvoiceSetting updated successfully", financeInvoiceSettingEntity);
    }
}