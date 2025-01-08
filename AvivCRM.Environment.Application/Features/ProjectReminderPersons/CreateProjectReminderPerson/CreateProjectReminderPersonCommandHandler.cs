#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using FluentValidation;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.CreateProjectReminderPerson;
internal class CreateProjectReminderPersonCommandHandler(
    IValidator<CreateProjectReminderPersonRequest> validator,
    IProjectReminderPerson _projectReminderPersonRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateProjectReminderPersonCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(CreateProjectReminderPersonCommand request,
        CancellationToken cancellationToken)
    {
        var validate = await validator.ValidateAsync(request.ProjectReminderPerson);
        if (!validate.IsValid)
        {
            var errorList = string.Join("; ", validate.Errors.Select(error => error.ErrorMessage));
            return new ServerResponse(Message: errorList);
        }

        var projectReminderPersonEntity = mapper.Map<ProjectReminderPerson>(request.ProjectReminderPerson);

        try
        {
            _projectReminderPersonRepository.Add(projectReminderPersonEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: "Error Occured: " + ex.Message);
        }

        return new ServerResponse(true, "Project Reminder Person created successfully", projectReminderPersonEntity);
    }
}