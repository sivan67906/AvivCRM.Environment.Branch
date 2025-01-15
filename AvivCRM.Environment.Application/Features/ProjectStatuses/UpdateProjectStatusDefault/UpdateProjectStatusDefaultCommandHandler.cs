#region

using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.UpdateProjectStatusDefault;
internal class UpdateProjectStatusDefaultCommandHandler(
    IProjectStatus _projectStatusRepository,
    IUnitOfWork _unitOfWork) : IRequestHandler<UpdateProjectStatusDefaultCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateProjectStatusDefaultCommand request,
        CancellationToken cancellationToken)
    {
        // Validate Request
        //var validate = await _validator.ValidateAsync(request.ProjectStatus);
        //if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the Project Status Default exists
        var projectStatuses = await _projectStatusRepository.GetAllAsync();
        if (projectStatuses is null)
        {
            return new ServerResponse(Message: "No Project Status Defaults Found");
        }

        ProjectStatus selectedProjectStatus = new();

        try
        {
            // Update the project Default Status
            foreach (var entity in projectStatuses)
            {
                if (entity.Id == request.ProjectStatus.Id)
                {
                    entity.Id = request.ProjectStatus.Id;
                    entity.IsDefaultStatus = true;
                    entity.ModifiedOn = DateTime.Now;
                    selectedProjectStatus = entity;
                    _projectStatusRepository.Update(entity);
                }
                else
                {
                    if (entity.IsDefaultStatus)
                    {
                        entity.ModifiedOn = DateTime.Now;
                    }

                    entity.IsDefaultStatus = false;
                    _projectStatusRepository.Update(entity);
                }
            }

            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Project Status Default updated successfully", selectedProjectStatus);
    }
}