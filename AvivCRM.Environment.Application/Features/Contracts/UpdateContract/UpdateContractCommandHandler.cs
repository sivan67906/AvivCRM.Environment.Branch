using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Contracts.UpdateContract;
internal class UpdateContractCommandHandler(IValidator<UpdateContractRequest> _validator, IContract _contractRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateContractCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Contract);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the Contract exists
        var contract = await _contractRepository.GetByIdAsync(request.Contract.Id);
        if (contract is null) return new ServerResponse(Message: "Contract Not Found");

        // Map the request to the entity
        var contractEntity = mapper.Map<Contract>(request.Contract);

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

        return new ServerResponse(IsSuccess: true, Message: "Contract Updated Successfully", Data: contract);
    }
}