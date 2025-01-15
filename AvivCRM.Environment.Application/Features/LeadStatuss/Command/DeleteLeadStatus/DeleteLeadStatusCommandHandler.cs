#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadStatuss.Command.DeleteLeadStatus;
internal class DeleteLeadStatusCommandHandler(
    ILeadStatus _leadStatusRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteLeadStatusCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteLeadStatusCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        LeadStatus? leadStatus = await _leadStatusRepository.GetByIdAsync(request.Id);
        if (leadStatus is null)
        {
            return new ServerResponse(Message: "Lead Status Not Found");
        }

        // Map the request to the entity
        LeadStatus delMapEntity = mapper.Map<LeadStatus>(leadStatus);

        try
        {
            // Delete Lead Status
            _leadStatusRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Lead Status deleted successfully", delMapEntity);
    }
}