using AutoMapper;
using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Domain.Contracts.Project;
using AvivCRM.Environment.Domain.Responses;
using MediatR;

namespace AvivCRM.Environment.Application.Features.ProjectReminderPersons.GetProjectReminderPersonById;

internal class GetProjectReminderPersonByIdQueryHandler(IProjectReminderPerson projectReminderPersonRepository, IMapper mapper) : IRequestHandler<GetProjectReminderPersonByIdQuery, ServerResponse>
{
    public async Task<ServerResponse> Handle(GetProjectReminderPersonByIdQuery request, CancellationToken cancellationToken)
    {
        // Get the Project Reminder Person by id
        var projectReminderPerson = await projectReminderPersonRepository.GetByIdAsync(request.Id);
        if (projectReminderPerson is null) return new ServerResponse(Message: "Project Reminder Person Not Found");

        // Map the entity to the response
        var projectReminderPersonResponse = mapper.Map<GetProjectReminderPerson>(projectReminderPerson); // <DTO> (parameter)
        if (projectReminderPersonResponse is null) return new ServerResponse(Message: "Project Reminder Person Not Found");

        return new ServerResponse(IsSuccess: true, Message: "Project Reminder Person", Data: projectReminderPersonResponse);
    }
}









