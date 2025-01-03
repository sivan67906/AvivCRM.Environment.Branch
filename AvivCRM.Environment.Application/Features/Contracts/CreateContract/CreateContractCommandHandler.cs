﻿using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Contracts.CreateContract;
internal class CreateContractCommandHandler(IValidator<CreateContractRequest> validator,
    IContract _contractRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateContractCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.Contract);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var contractEntity = mapper.Map<Contract>(request.Contract);

        try
        {
            _contractRepository.Add(contractEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Contract Created Succcessfully", Data: contractEntity);
    }
}
