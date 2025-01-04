using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.GetAllProjectReminderPerson;
internal class GetAllProjectReminderPersonQueryHandler(IProjectReminderPerson _projectReminderPersonRepository, IMapper mapper) : IRequestHandler<GetAllProjectReminderPersonQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetAllProjectReminderPersonQuery request, CancellationToken cancellationToken)
    {
        // Get all plan types
        var projectReminderPerson = await _projectReminderPersonRepository.GetAllAsync();
        if (projectReminderPerson is null) return new ServerResponse(Message: "No Project Reminder Person Found");

        // Map the plan types to the response
        var leadSourcResponse = mapper.Map<IEnumerable<GetProjectReminderPerson>>(projectReminderPerson);
        if (leadSourcResponse is null) return new ServerResponse(Message: "Project Reminder Person Not Found");

        return new ServerResponse(IsSuccess: true, Message: "List of Project Reminder Persons", Data: leadSourcResponse);
    }
}











