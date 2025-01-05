using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.Plannings.CreatePlanning;
internal class CreatePlanningCommandHandler(IValidator<CreatePlanningRequest> _validator, IPlanning _planningRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<CreatePlanningCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreatePlanningCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.Planning);

        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));


        // Map the request to the entity
        var planningEntity = mapper.Map<Planning>(request.Planning);

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

        return new ServerResponse(IsSuccess: true, Message: "Planning created successfully", Data: planningEntity);
    }
}