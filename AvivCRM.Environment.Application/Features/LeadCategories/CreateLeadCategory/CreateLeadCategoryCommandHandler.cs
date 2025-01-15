#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.CreateLeadCategory;
internal class CreateLeadCategoryCommandHandler(
    IValidator<CreateLeadCategoryRequest> validator,
    ILeadCategory _leadCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateLeadCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateLeadCategoryCommand request, CancellationToken cancellationToken)
    {
        // validate check
        var validate = await validator.ValidateAsync(request.LeadCategory);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        // Mapping Entity
        var leadCategoryEntity = mapper.Map<LeadCategory>(request.LeadCategory);

        try
        {
            _leadCategoryRepository.Add(leadCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Lead Categories created successfully", leadCategoryEntity);
    }
}