#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.Applicationss.Command.DeleteApplication;
internal class DeleteApplicationCommandHandler(
    IApplication _applicationRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteApplicationCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        Applications? application = await _applicationRepository.GetByIdAsync(request.Id);
        if (application is null)
        {
            return new ServerResponse(Message: "Application Not Found");
        }

        // Map the request to the entity
        Applications delMapEntity = mapper.Map<Applications>(application);

        try
        {
            // Delete Application
            _applicationRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Application deleted successfully", delMapEntity);
    }
}