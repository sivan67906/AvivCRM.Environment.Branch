#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities.Lead;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.LeadAgents.Command.DeleteLeadAgent;
internal class DeleteLeadAgentCommandHandler(ILeadAgent _leadAgentRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteLeadAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteLeadAgentCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        LeadAgent? leadAgent = await _leadAgentRepository.GetByIdAsync(request.Id);
        if (leadAgent is null)
        {
            return new ServerResponse(Message: "Lead Agent Not Found");
        }

        // Map the request to the entity
        LeadAgent delMapEntity = mapper.Map<LeadAgent>(leadAgent);

        try
        {
            // Delete plan type
            _leadAgentRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Lead Agent deleted successfully", delMapEntity);
    }
}