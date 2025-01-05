using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Lead;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.LeadStatuss.DeleteLeadStatus;
internal class DeleteLeadStatusCommandHandler(ILeadStatus _leadStatusRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteLeadStatusCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteLeadStatusCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var leadStatus = await _leadStatusRepository.GetByIdAsync(request.Id);
        if (leadStatus is null) return new ServerResponse(Message: "Lead Status Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<LeadStatus>(leadStatus);

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

        return new ServerResponse(IsSuccess: true, Message: "Lead Status deleted successfully", Data: delMapEntity);
    }
}
