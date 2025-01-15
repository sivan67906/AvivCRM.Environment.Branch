#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Command.CreateLeadAgent;
internal class CreateLeadAgentCommandHandler(
    IValidator<CreateLeadAgentRequest> _validator,
    ILeadAgent _leadAgentRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<CreateLeadAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateLeadAgentCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.LeadAgent);

        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Lead Agent already exists
        bool isAvailable = await _leadAgentRepository.IsAvailableByNameAsync(request.LeadAgent.Name);
        if (isAvailable)
        {
            return new ServerResponse(Message: "Lead Agent Already Exists");
        }

        // Map the request to the entity
        LeadAgent leadAgentEntity = mapper.Map<LeadAgent>(request.LeadAgent);

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

        return new ServerResponse(true, "Lead Agent created successfully", leadAgentEntity);
    }
}