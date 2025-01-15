#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Command.UpdateFinanceInvoiceTemplateSetting;
internal class UpdateFinanceInvoiceTemplateSettingCommandHandler(
    IValidator<UpdateFinanceInvoiceTemplateSettingRequest> _validator,
    IFinanceInvoiceTemplateSetting _financeInvoiceTemplateSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateFinanceInvoiceTemplateSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateFinanceInvoiceTemplateSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.FinanceInvoiceTemplateSetting);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        FinanceInvoiceTemplateSetting? financeInvoiceTemplateSetting =
            await _financeInvoiceTemplateSettingRepository.GetByIdAsync(request.FinanceInvoiceTemplateSetting.Id);
        if (financeInvoiceTemplateSetting is null)
        {
            return new ServerResponse(Message: "Finance Invoice Template Setting Not Found");
        }

        // Map the request to the entity
        FinanceInvoiceTemplateSetting financeInvoiceTemplateSettingEntity =
            mapper.Map<FinanceInvoiceTemplateSetting>(request.FinanceInvoiceTemplateSetting);

        try
        {
            // Update the lead Source
            _financeInvoiceTemplateSettingRepository.Update(financeInvoiceTemplateSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Finance Invoice Template Setting updated successfully",
            financeInvoiceTemplateSettingEntity);
    }
}