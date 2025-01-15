#region

using AutoMapper;
using AvivCRM.Environment.Application.Contracts.Project;
using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Domain.Interfaces;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

#endregion

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.Command.DeleteProjectReminderPerson;
internal class DeleteProjectReminderPersonCommandHandler(
    IProjectReminderPerson _projectReminderPersonRepository,
    IUnitOfWork _unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteProjectReminderPersonCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteProjectReminderPersonCommand request,
        CancellationToken cancellationToken)
    {
        // Is Found
        ProjectReminderPerson? projectReminderPerson = await _projectReminderPersonRepository.GetByIdAsync(request.Id);
        if (projectReminderPerson is null)
        {
            return new ServerResponse(Message: "Project Reminder Person Not Found");
        }

        // Map the request to the entity
        ProjectReminderPerson delMapEntity = mapper.Map<ProjectReminderPerson>(projectReminderPerson);

        try
        {
            // Delete Project Reminder
            _projectReminderPersonRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(true, "Project Reminder Person deleted successfully", delMapEntity);
    }
}