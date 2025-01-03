using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.CreateFinanceInvoiceTemplateSetting;

internal class CreateFinanceInvoiceTemplateSettingCommandHandler(IValidator<CreateFinanceInvoiceTemplateSettingRequest> validator,
    IFinanceInvoiceTemplateSetting _financeInvoiceTemplateSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateFinanceInvoiceTemplateSettingCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateFinanceInvoiceTemplateSettingCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.FinanceInvoiceTemplateSetting);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var financeInvoiceTemplateSettingEntity = mapper.Map<FinanceInvoiceTemplateSetting>(request.FinanceInvoiceTemplateSetting);

        try
        {
            _financeInvoiceTemplateSettingRepository.Add(financeInvoiceTemplateSettingEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Finance Invoice Template Setting Created Succcessfully", Data: financeInvoiceTemplateSettingEntity);
    }
}











