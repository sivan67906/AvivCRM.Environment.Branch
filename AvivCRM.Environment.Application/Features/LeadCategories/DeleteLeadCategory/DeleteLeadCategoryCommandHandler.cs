#region

using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadCategories.DeleteLeadCategory;
internal class DeleteLeadCategoryCommandHandler(
    ILeadCategory _leadCategoryRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteLeadCategoryCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteLeadCategoryCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var leadCategory = await _leadCategoryRepository.GetByIdAsync(request.Id);
        if (leadCategory is null)
        {
            return new ServerResponse(Message: "Lead Category Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<LeadCategory>(leadCategory);

        try
        {
            // Delete plan type
            _leadCategoryRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Lead Category deleted successfully", delMapEntity);
    }
}