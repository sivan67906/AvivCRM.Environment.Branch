#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Currencies.DeleteCurrency;
internal class DeleteCurrencyCommandHandler(ICurrency _currencyRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteCurrencyCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var currency = await _currencyRepository.GetByIdAsync(request.Id);
        if (currency is null)
        {
            return new ServerResponse(Message: "Currency Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<Currency>(currency);

        try
        {
            // Delete Currency
            _currencyRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Currency deleted successfully", delMapEntity);
    }
}