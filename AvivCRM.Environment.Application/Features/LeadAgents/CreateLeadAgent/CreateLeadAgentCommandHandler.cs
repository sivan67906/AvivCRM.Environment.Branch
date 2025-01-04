using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadAgents.CreateLeadAgent;

internal class CreatePlanTypeCommandHandler(IValidator<CreateLeadAgentRequest> _validator, ILeadAgent _leadAgentRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<CreateLeadAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateLeadAgentCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validate = await _validator.ValidateAsync(request.LeadAgent);

        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the Lead Agent already exists
        var isAvailable = await _leadAgentRepository.IsAvailableByNameAsync(request.LeadAgent.Name);
        if (isAvailable) return new ServerResponse(Message: "Lead Agent Already Exists");

        // Map the request to the entity
        var leadAgentEntity = mapper.Map<LeadAgent>(request.LeadAgent);

        try
        {
            // Add the Lead Agent
            _leadAgentRepository.Add(leadAgentEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Lead Agent created successfully", Data: leadAgentEntity);
    }
}

