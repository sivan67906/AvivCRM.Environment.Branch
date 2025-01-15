﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.CreateTax;
internal class CreateTaxCommandHandler(
    IValidator<CreateTaxRequest> validator,
    ITax _taxRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateTaxCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
    {
        // Check Validate Tax
        var validate = await validator.ValidateAsync(request.Tax);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        // Mapping Tax Entity
        var taxEntity = mapper.Map<Tax>(request.Tax);

        try
        {
            _taxRepository.Add(taxEntity);
            await _unitOfWork.SaveChangesAsync(); // Save Tax
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Tax created successfully", taxEntity);
    }
}