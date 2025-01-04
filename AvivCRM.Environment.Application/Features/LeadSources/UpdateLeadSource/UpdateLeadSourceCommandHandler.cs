using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadSources.UpdateLeadSource;

internal class UpdateLeadSourceCommandHandler(IValidator<UpdateLeadSourceRequest> _validator, ILeadSource _leadSourceRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateLeadSourceCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateLeadSourceCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.LeadSource);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the plan type exists
        var leadSource = await _leadSourceRepository.GetByIdAsync(request.LeadSource.Id);
        if (leadSource is null) return new ServerResponse(Message: "Lead Source Not Found");

        // Map the request to the entity
        var leadSourceEntity = mapper.Map<LeadSource>(request.LeadSource);

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

        return new ServerResponse(IsSuccess: true, Message: "Lead Source updated successfully", Data: leadSource);
    }
}