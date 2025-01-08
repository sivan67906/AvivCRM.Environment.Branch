﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Domain.Contracts.Finance;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.FinanceInvoiceSettings.GetAllFinanceInvoiceSetting;
internal class GetAllFinanceInvoiceSettingQueryHandler(
    IFinanceInvoiceSetting _financeInvoiceSettingRepository,
    IMapper mapper) : IRequestHandler<GetAllFinanceInvoiceSettingQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllFinanceInvoiceSettingQuery request,
        CancellationToken cancellationToken)
    {
        // Get all plan types
        var financeInvoiceSetting = await _financeInvoiceSettingRepository.GetAllAsync();
        if (financeInvoiceSetting is null)
        {
            return new ServerResponse(Message: "No Finance Invoice Setting Found");
        }

        // Map the plan types to the response
        var financeInvoiceSettingResponse = mapper.Map<IEnumerable<GetFinanceInvoiceSetting>>(financeInvoiceSetting);
        if (financeInvoiceSettingResponse is null)
        {
            return new ServerResponse(Message: "Finance Invoice  Setting Not Found");
        }

        return new ServerResponse(true, "List of Finance Invoice Settings", financeInvoiceSettingResponse);
    }
}