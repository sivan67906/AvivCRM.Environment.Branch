#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.Command.CreateLeadStatus;
internal class CreateLeadStatusCommandHandler(
    IValidator<CreateLeadStatusRequest> validator,
    ILeadStatus _leadStatusRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateLeadStatusCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateLeadStatusCommand request, CancellationToken cancellationToken)
    {
        // Validate Check
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.LeadStatus);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        // Mapping Entity
        LeadStatus leadStatusEntity = mapper.Map<LeadStatus>(request.LeadStatus);

        try
        {
            _leadStatusRepository.Add(leadStatusEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Lead Status created successfully", leadStatusEntity);
    }
}