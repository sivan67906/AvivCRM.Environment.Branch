#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceTemplateSettings.Command.DeleteFinanceInvoiceTemplateSetting;
internal class DeleteFinanceInvoiceTemplateSettingCommandHandler(
    IFinanceInvoiceTemplateSetting _financeInvoiceTemplateSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteFinanceInvoiceTemplateSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteFinanceInvoiceTemplateSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        FinanceInvoiceTemplateSetting? financeInvoiceTemplateSetting = await _financeInvoiceTemplateSettingRepository.GetByIdAsync(request.Id);
        if (financeInvoiceTemplateSetting is null)
        {
            return new ServerResponse(Message: "Finance Invoice Template Setting Not Found");
        }

        // Map the request to the entity
        FinanceInvoiceTemplateSetting delMapEntity = mapper.Map<FinanceInvoiceTemplateSetting>(financeInvoiceTemplateSetting);

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

        return new ServerResponse(true, "Finance Invoice Template Setting deleted successfully",
            financeInvoiceTemplateSetting);
    }
}