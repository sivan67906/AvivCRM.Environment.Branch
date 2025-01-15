#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities.Finance;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.Command.DeleteFinanceInvoiceSetting;
internal class DeleteFinanceInvoiceSettingCommandHandler(
    IFinanceInvoiceSetting _financeInvoiceSettingRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteFinanceInvoiceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteFinanceInvoiceSettingCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        FinanceInvoiceSetting? financeInvoiceSetting = await _financeInvoiceSettingRepository.GetByIdAsync(request.Id);
        if (financeInvoiceSetting is null)
        {
            return new ServerResponse(Message: "Finance Invoice Setting Not Found");
        }

        // Map the request to the entity
        FinanceInvoiceSetting delMapEntity = mapper.Map<FinanceInvoiceSetting>(financeInvoiceSetting);

        try
        {
            // Delete finance invoice Setting
            _financeInvoiceSettingRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Finance Invoice Setting deleted successfully", financeInvoiceSetting);
    }
}