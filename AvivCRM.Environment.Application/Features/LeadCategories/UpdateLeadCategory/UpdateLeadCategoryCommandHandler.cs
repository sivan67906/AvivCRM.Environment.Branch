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

namespace AvivCRM.Environment.Application.Features.LeadCategories.UpdateLeadCategory;
internal class UpdateLeadCategoryCommandHandler(
    IValidator<UpdateLeadCategoryRequest> _validator,
    ILeadCategory _leadCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateLeadCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateLeadCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.LeadCategory);
        if (!validate.IsValid)
        {
            return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));
        }

        // Check if the Lead Category exists
        var leadCategory = await _leadCategoryRepository.GetByIdAsync(request.LeadCategory.Id);
        if (leadCategory is null)
        {
            return new ServerResponse(Message: "Lead Category Not Found");
        }

        // Map the request to the entity
        var leadCategoryEntity = mapper.Map<LeadCategory>(request.LeadCategory);

        try
        {
            // Update the lead Source
            _leadCategoryRepository.Update(leadCategoryEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Lead Category updated successfully", leadCategoryEntity);
    }
}