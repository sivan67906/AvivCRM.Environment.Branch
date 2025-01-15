#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.Command.UpdateLeadSource;
internal class UpdateLeadSourceCommandHandler(
    IValidator<UpdateLeadSourceRequest> _validator,
    ILeadSource _leadSourceRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateLeadSourceCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateLeadSourceCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        FluentValidation.Results.ValidationResult validate = await _validator.ValidateAsync(request.LeadSource);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the plan type exists
        LeadSource? leadSource = await _leadSourceRepository.GetByIdAsync(request.LeadSource.Id);
        if (leadSource is null)
        {
            return new ServerResponse(Message: "Lead Source Not Found");
        }

        // Map the request to the entity
        LeadSource leadSourceEntity = mapper.Map<LeadSource>(request.LeadSource);

        try
        {
            // Update the lead Source
            _leadSourceRepository.Update(leadSourceEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Lead Source updated successfully", leadSourceEntity);
    }
}