using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Project;
public interface IProjectSetting
{
    void Add(ProjectSetting projectSetting);
    void Update(ProjectSetting projectSetting);
    void Delete(ProjectSetting projectSetting);
    Task<ProjectSetting?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProjectSetting>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string projectSettingName);
}









