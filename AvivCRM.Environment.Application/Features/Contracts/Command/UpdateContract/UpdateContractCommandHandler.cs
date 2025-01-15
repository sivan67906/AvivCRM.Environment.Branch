#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.Command.UpdateContract;
internal class UpdateContractCommandHandler(
    IValidator<UpdateContractRequest> _validator,
    IContract _contractRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateContractCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Contract);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Contract exists
        Contract? contract = await _contractRepository.GetByIdAsync(request.Contract.Id);
        if (contract is null)
        {
            return new ServerResponse(Message: "Contract Not Found");
        }

        // Map the request to the entity
        Contract contractEntity = mapper.Map<Contract>(request.Contract);

        try
        {
            // Update the Contract
            _contractRepository.Update(contractEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Contract updated successfully", contractEntity);
    }
}