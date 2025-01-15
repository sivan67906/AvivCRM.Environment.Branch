#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.Command.UpdateCurrency;
internal class UpdateCurrencyCommandHandler(
    IValidator<UpdateCurrencyRequest> _validator,
    ICurrency _currencyRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCurrencyCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Currency);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Currency exists
        Currency? currency = await _currencyRepository.GetByIdAsync(request.Currency.Id);
        if (currency is null)
        {
            return new ServerResponse(Message: "Currency Not Found");
        }

        // Map the request to the entity
        Currency currencyEntity = mapper.Map<Currency>(request.Currency);

        try
        {
            // Update the Currency
            _currencyRepository.Update(currencyEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Currency updated successfully", currencyEntity);
    }
}