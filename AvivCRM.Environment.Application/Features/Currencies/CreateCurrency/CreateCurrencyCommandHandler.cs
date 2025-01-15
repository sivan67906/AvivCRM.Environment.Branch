#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.CreateCurrency;
internal class CreateCurrencyCommandHandler(
    IValidator<CreateCurrencyRequest> validator,
    ICurrency _currencyRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateCurrencyCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        // Valid Check
        var validate = await validator.ValidateAsync(request.Currency);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        // Mapping Currency Entity
        var currencyEntity = mapper.Map<Currency>(request.Currency);

        try
        {
            _currencyRepository.Add(currencyEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Currency created successfully", currencyEntity);
    }
}