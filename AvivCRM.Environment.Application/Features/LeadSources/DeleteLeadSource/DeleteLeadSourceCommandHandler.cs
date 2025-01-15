#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadSources.DeleteLeadSource;
internal class DeleteLeadSourceCommandHandler(
    ILeadSource _leadSourceRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteLeadSourceCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteLeadSourceCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var leadSource = await _leadSourceRepository.GetByIdAsync(request.Id);
        if (leadSource is null)
        {
            return new ServerResponse(Message: "Lead Source Not Found");
        }

        // Map the request to the entity
        var delMapEntity = mapper.Map<LeadSource>(leadSource);

        try
        {
            // Delete plan type
            _leadSourceRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Lead Source deleted successfully", delMapEntity);
    }
}