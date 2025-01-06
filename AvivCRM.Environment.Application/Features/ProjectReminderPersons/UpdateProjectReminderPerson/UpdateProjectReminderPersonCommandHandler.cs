using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.UpdateProjectReminderPerson;

internal class UpdateProjectReminderPersonCommandHandler(IValidator<UpdateProjectReminderPersonRequest> _validator, IProjectReminderPerson _projectReminderPersonRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<UpdateProjectReminderPersonCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(UpdateProjectReminderPersonCommand request, CancellationToken cancellationToken)
    {
        // Validate Request
        var validate = await _validator.ValidateAsync(request.ProjectReminderPerson);
        if (!validate.IsValid) return new ServerResponse(Message: string.Join("; ", validate.Errors.Select(error => error.ErrorMessage)));

        // Check if the Project Reminder Person exists
        var projectReminderPerson = await _projectReminderPersonRepository.GetByIdAsync(request.ProjectReminderPerson.Id);
        if (projectReminderPerson is null) return new ServerResponse(Message: "Project Reminder Person Not Found");

        // Map the request to the entity
        var projectReminderPersonEntity = mapper.Map<ProjectReminderPerson>(request.ProjectReminderPerson);

        try
        {
            // Update the Project Reminder Person
            _projectReminderPersonRepository.Update(projectReminderPersonEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Project Reminder Person updated successfully", Data: projectReminderPersonEntity);
    }
}









