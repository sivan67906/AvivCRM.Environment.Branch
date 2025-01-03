using AutoMapper;
using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.DeleteProjectReminderPerson;

internal class DeleteProjectReminderPersonCommandHandler(IProjectReminderPerson _projectReminderPersonRepository, IUnitOfWork _unitOfWork, IMapper mapper) : IRequestHandler<DeleteProjectReminderPersonCommand, ServerResponse>
{
    public async Task<ServerResponse> Handle(DeleteProjectReminderPersonCommand request, CancellationToken cancellationToken)
    {
        // Is Found
        var projectReminderPerson = await _projectReminderPersonRepository.GetByIdAsync(request.Id);
        if (projectReminderPerson is null) return new ServerResponse(Message: "Project Reminder Person Not Found");

        // Map the request to the entity
        var delMapEntity = mapper.Map<ProjectReminderPerson>(projectReminderPerson);

        try
        {
            // Delete plan type
            _projectReminderPersonRepository.Delete(delMapEntity);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServerResponse(Message: ex.Message);
        }

        return new ServerResponse(IsSuccess: true, Message: "Project Reminder Person Deleted Successfully", Data: projectReminderPerson);
    }
}











