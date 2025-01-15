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

namespace AvivCRM.Environment.Application.Features.LeadAgents.Command.UpdateLeadAgent;
internal class UpdateLeadAgentCommandHandler(
    IValidator<UpdateLeadAgentRequest> _validator,
    ILeadAgent _leadAgentRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateLeadAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateLeadAgentCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.LeadAgent);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Lead Agent exists
        LeadAgent? leadAgent = await _leadAgentRepository.GetByIdAsync(request.LeadAgent.Id);
        if (leadAgent is null)
        {
            return new ServerResponse(Message: "Lead Agent Not Found");
        }

        // Map the request to the entity
        LeadAgent leadAgentEntity = mapper.Map<LeadAgent>(request.LeadAgent);

        try
        {
            // Update the Lead Agent
            _leadAgentRepository.Update(leadAgentEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Lead Agent updated successfully", leadAgentEntity);
    }
}