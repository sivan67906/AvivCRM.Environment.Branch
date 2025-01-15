#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectStatuses.Command.CreateProjectStatus;
internal class CreateProjectStatusCommandHandler(
    IValidator<CreateProjectStatusRequest> validator,
    IProjectStatus _projectStatusRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateProjectStatusCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validate = await validator.ValidateAsync(request.ProjectStatus);
        if (!validate.IsValid)
        {
            string errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }


        ProjectStatus projectStatusEntity = mapper.Map<ProjectStatus>(request.ProjectStatus);

        try
        {
            _projectStatusRepository.Add(projectStatusEntity);
            await _unitOfWork.SaveChangesAsync();


            if (projectStatusEntity.IsDefaultStatus)
            {
                IEnumerable<ProjectStatus> projectStatuses = await _projectStatusRepository.GetAllAsync();

                // Update the project Default Status
                foreach (ProjectStatus entity in projectStatuses)
                {
                    if (entity.Id == projectStatusEntity.Id)
                    {
                        //entity.Id = projectStatusEntity.Id;
                        //entity.IsDefaultStatus = true;
                        //entity.ModifiedOn = DateTime.Now;
                        //selectedProjectStatus = entity;
                        //_projectStatusRepository.Update(entity);
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
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Project Status created successfully", projectStatusEntity);
    }
}