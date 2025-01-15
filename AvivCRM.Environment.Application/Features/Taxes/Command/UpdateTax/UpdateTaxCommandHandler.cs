#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Taxes.Command.UpdateTax;
internal class UpdateTaxCommandHandler(
    IValidator<UpdateTaxRequest> _validator,
    ITax _taxRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateTaxCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Tax);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the tax exists
        Tax? tax = await _taxRepository.GetByIdAsync(request.Tax.Id);
        if (tax is null)
        {
            return new ServerResponse(Message: "Tax Not Found");
        }

        // Map the request to the entity
        Tax taxEntity = mapper.Map<Tax>(request.Tax);

        try
        {
            // Update the tax
            _taxRepository.Update(taxEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Tax updated successfully", taxEntity);
    }
}