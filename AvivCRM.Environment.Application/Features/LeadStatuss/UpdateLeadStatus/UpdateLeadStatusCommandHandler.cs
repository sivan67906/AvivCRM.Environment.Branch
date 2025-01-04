using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.UpdateLeadStatus;
internal class UpdateLeadStatusCommandHandler(IValidator<UpdateLeadStatusRequest> _validator, ILeadStatus _leadStatusRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateLeadStatusCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateLeadStatusCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.LeadStatus);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the Lead Status exists
        var leadStatus = await _leadStatusRepository.GetByIdAsync(request.LeadStatus.Id);
        if (leadStatus is null) return new ServerResponse(Message: "Lead Status Not Found");

        // Map the request to the entity
        var leadStatusEntity = mapper.Map<LeadStatus>(request.LeadStatus);

        try
        {
            // Update the lead Status
            _leadStatusRepository.Update(leadStatusEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Lead Status updated successfully", Data: leadStatus);
    }
}
