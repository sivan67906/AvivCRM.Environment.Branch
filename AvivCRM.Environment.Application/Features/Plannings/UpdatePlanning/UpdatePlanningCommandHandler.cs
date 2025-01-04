﻿using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Plannings.UpdatePlanning;
internal class UpdatePlanningCommandHandler(IValidator<UpdatePlanningRequest> _validator, IPlanning _planningRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdatePlanningCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdatePlanningCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.Planning);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the Planning exists
        var planning = await _planningRepository.GetByIdAsync(request.Planning.Id);
        if (planning is null) return new ServerResponse(Message: "Planning Not Found");

        // Map the request to the entity
        var planningEntity = mapper.Map<Planning>(request.Planning);

        try
        {
            // Update the Planning
            _planningRepository.Update(planningEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Planning Updated Successfully", Data: planning);
    }
}
