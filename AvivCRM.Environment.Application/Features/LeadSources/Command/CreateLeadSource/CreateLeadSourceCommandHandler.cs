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

namespace AvivCRM.Environment.Application.Features.LeadSources.Command.CreateLeadSource;
internal class CreateLeadSourceCommandHandler(
    IValidator<CreateLeadSourceRequest> validator,
    ILeadSource _leadSourceRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateLeadSourceCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateLeadSourceCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.LeadSource);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        LeadSource leadSourceEntity = mapper.Map<LeadSource>(request.LeadSource);

        try
        {
            _leadSourceRepository.Add(leadSourceEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Lead Source created successfully", leadSourceEntity);
    }
}