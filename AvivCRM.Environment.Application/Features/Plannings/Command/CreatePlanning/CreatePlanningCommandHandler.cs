﻿#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Plannings.Command.CreatePlanning;
internal class CreatePlanningCommandHandler(
    IValidator<CreatePlanningRequest> _validator,
    IPlanning _planningRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreatePlanningCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreatePlanningCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.Planning);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }


        // Map the request to the entity
        Planning planningEntity = mapper.Map<Planning>(request.Planning);

        try
        {
            // Add the Planning
            _planningRepository.Add(planningEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Planning created successfully", planningEntity);
    }
}