using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ToggleValues.DeleteToggleValue;

internal class DeleteToggleValueCommandHandler(IToggleValue _toggleValueRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteToggleValueCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteToggleValueCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var toggleValue = await _toggleValueRepository.GetByIdAsync(request.Id);
        if (toggleValue is null) return new ServerResponse(Message: "Toggle Value Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<ToggleValue>(toggleValue);

        try
        {
            // Delete Toggle Value
            _toggleValueRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Toggle Value deleted successfully", Data: delMapEntity);
    }
}










































