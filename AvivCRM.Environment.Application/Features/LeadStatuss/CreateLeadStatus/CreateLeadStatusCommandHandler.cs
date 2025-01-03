﻿using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.CreateLeadStatus;
internal class CreateLeadStatusCommandHandler(IValidator<CreateLeadStatusRequest> validator,
    ILeadStatus _leadStatusRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<CreateLeadStatusCommand, ServerResponse>
{

    public async Task<ServerResponse> Handle(CreateLeadStatusCommand request, CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.LeadStatus);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }
        // Mapping
        var leadStatusEntity = mapper.Map<LeadStatus>(request.LeadStatus);

        try
        {
            _leadStatusRepository.Add(leadStatusEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Lead Status Created Succcessfully", Data: leadStatusEntity);
    }
}
