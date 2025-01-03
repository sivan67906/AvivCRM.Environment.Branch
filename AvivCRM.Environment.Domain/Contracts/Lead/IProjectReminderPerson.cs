using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Project;
public interface IProjectReminderPerson
{
    void Add(ProjectReminderPerson projectReminderPerson);
    void Update(ProjectReminderPerson projectReminderPerson);
    void Delete(ProjectReminderPerson projectReminderPerson);
    Task<ProjectReminderPerson?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProjectReminderPerson>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string projectReminderPersonName);
}









