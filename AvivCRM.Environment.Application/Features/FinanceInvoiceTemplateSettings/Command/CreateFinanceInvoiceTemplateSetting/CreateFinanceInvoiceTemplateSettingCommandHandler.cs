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

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Command.CreateFinanceInvoiceTemplateSetting;
internal class CreateFinanceInvoiceTemplateSettingCommandHandler(
    IValidator<CreateFinanceInvoiceTemplateSettingRequest> validator,
    IFinanceInvoiceTemplateSetting _financeInvoiceTemplateSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateFinanceInvoiceTemplateSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateFinanceInvoiceTemplateSettingCommand request,
        CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.FinanceInvoiceTemplateSetting);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        FinanceInvoiceTemplateSetting financeInvoiceTemplateSettingEntity =
            mapper.Map<FinanceInvoiceTemplateSetting>(request.FinanceInvoiceTemplateSetting);

        try
        {
            _financeInvoiceTemplateSettingRepository.Add(financeInvoiceTemplateSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Finance Invoice Template Setting created successfully",
            financeInvoiceTemplateSettingEntity);
    }
}