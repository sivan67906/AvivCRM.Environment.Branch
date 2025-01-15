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

namespace AvivCRM.Environment.Application.Features.Contracts.Command.CreateContract;
internal class CreateContractCommandHandler(
    IValidator<CreateContractRequest> validator,
    IContract _contractRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateContractCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        // Validate request
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.Contract);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        // Mapping Entity
        Contract contractEntity = mapper.Map<Contract>(request.Contract);

        try
        {
            _contractRepository.Add(contractEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Contract created successfully", contractEntity);
    }
}