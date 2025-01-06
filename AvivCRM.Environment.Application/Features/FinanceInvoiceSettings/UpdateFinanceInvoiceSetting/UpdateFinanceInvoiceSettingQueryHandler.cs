//using AutoMapper;
//using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
//using AvivCRM.Environment.Domain.Contracts;
//using AvivCRM.Environment.Domain.Contracts.Finance;
//using AvivCRM.Environment.Domain.Entities;
//using AvivCRM.Environment.Domain.Responses;
//using FluentValidation;
//using MediatR;

//namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.UpdateFinanceInvoiceSetting;
//internal class UpdateFinanceInvoiceSettingCommandHandler(IValidator<UpdateFinanceInvoiceSettingRequest> _validator, IFinanceInvoiceSetting _financeInvoiceSettingRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateFinanceInvoiceSettingCommand, ServerResponse>
//{
//    public async Task<ServerResponse> Handle(UpdateFinanceInvoiceSettingCommand request, CancellationToken cancellationToken)
//    {
//        // Validate Request
//        var validate = await _validator.ValidateAsync(request.FinanceInvoiceSetting);
//        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

//        // Check if the FinanceInvoiceSetting exists
//        var financeInvoiceSetting = await _financeInvoiceSettingRepository.GetByIdAsync(request.FinanceInvoiceSetting.Id);
//        if (financeInvoiceSetting is null) return new ServerResponse(Message: "FinanceInvoiceSetting Not Found");

//        // Map the request to the entity
//        var financeInvoiceSettingEntity = mapper.Map<FinanceInvoiceSetting>(request.FinanceInvoiceSetting);

//        try
//        {
//            // Update the FinanceInvoiceSetting
//            _financeInvoiceSettingRepository.Update(financeInvoiceSettingEntity);
//            await _unitOfWork.SaveChangesAsync();
//        }
//        catch (Exception ex)
//        {
//            return new ServerResponse(Message: ex.Message);
//        }

//        return new ServerResponse(IsSuccess: true, Message: "FinanceInvoiceSetting updated successfully", Data: financeInvoiceSettingEntity);
//    }
//}