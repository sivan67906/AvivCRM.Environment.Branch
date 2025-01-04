using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.DeleteProjectStatus;

internal class DeleteProjectStatusCommandHandler(IProjectStatus _projectStatusRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteProjectStatusCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteProjectStatusCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var projectStatus = await _projectStatusRepository.GetByIdAsync(request.Id);
        if (projectStatus is null) return new ServerResponse(Message: "Project Status Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<ProjectStatus>(projectStatus);

        try
        {
            // Delete plan type
            _projectStatusRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Project Status deleted successfully", Data: projectStatus);
    }
}











