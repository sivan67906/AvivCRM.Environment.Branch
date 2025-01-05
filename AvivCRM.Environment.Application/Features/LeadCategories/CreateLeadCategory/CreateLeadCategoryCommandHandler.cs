using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadCategories.CreateLeadCategory;

internal class CreateLeadCategoryCommandHandler(IValidator<CreateLeadCategoryRequest> validator,
    ILeadCategory _leadCategoryRepository, IUnitOfWork _unitOfWork, IMapper mapper)
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
            return new ServerResponse(Message: "Error Occured: " + ex.Message.ToString());
        }

        return new ServerResponse(IsSuccess: true, Message: "Lead Categories created successfully", Data: leadCategoryEntity);
    }
}


