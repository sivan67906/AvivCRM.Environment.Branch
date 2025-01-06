using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.DeleteFinanceInvoiceSetting;
internal class DeleteFinanceInvoiceSettingCommandHandler(IFinanceInvoiceSetting _financeInvoiceSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteFinanceInvoiceSettingCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteFinanceInvoiceSettingCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var financeInvoiceSetting = await _financeInvoiceSettingRepository.GetByIdAsync(request.Id);
        if (financeInvoiceSetting is null) return new ServerResponse(Message: "Finance Invoice Setting Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<FinanceInvoiceSetting>(financeInvoiceSetting);

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

        return new ServerResponse(IsSuccess: true, Message: "Finance Invoice Setting deleted successfully", Data: financeInvoiceSetting);
    }
}