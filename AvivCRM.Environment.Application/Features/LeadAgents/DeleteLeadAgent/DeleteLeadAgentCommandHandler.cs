using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadAgents.DeleteLeadAgent;

internal class DeleteLeadAgentCommandHandler(ILeadAgent _leadAgentRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteLeadAgentCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteLeadAgentCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var leadAgent = await _leadAgentRepository.GetByIdAsync(request.Id);
        if (leadAgent is null) return new ServerResponse(Message: "Lead Agent Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<LeadAgent>(leadAgent);

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

        return new ServerResponse(IsSuccess: true, Message: "Lead Agent deleted successfully", Data: delMapEntity);
    }
}

