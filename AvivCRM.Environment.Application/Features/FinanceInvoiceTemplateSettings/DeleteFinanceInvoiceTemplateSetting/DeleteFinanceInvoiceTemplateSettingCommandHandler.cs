using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.DeleteFinanceInvoiceTemplateSetting;

internal class DeleteFinanceInvoiceTemplateSettingCommandHandler(IFinanceInvoiceTemplateSetting _financeInvoiceTemplateSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteFinanceInvoiceTemplateSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteFinanceInvoiceTemplateSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var financeInvoiceTemplateSetting = await _financeInvoiceTemplateSettingRepository.GetByIdAsync(request.Id);
        if (financeInvoiceTemplateSetting is null) return new ServerResponse(Message: "Finance Invoice Template Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<FinanceInvoiceTemplateSetting>(financeInvoiceTemplateSetting);

        try
        {
            // Delete plan type
            _financeInvoiceTemplateSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Finance Invoice Template Setting Deleted Successfully", Data: financeInvoiceTemplateSetting);
    }
}











