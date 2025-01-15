#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Contracts.Command.DeleteContract;
internal class DeleteContractCommandHandler(IContract _contractRepository, IUnitOfWork _unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteContractCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        Contract? contract = await _contractRepository.GetByIdAsync(request.Id);
        if (contract is null)
        {
            return new ServerResponse(Message: "Contract Not Found");
        }

        // Map the request to the entity
        Contract delMapEntity = mapper.Map<Contract>(contract);

        try
        {
            // Delete Contract
            _contractRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Contract deleted successfully", delMapEntity);
    }
}