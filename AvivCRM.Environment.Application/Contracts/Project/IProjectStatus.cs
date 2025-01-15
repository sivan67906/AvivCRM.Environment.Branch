#region

using AvivCRM.Environment.Domain.Entities.Project;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Project;
public interface IProjectStatus
{
    void Add(ProjectStatus projectStatus);
    void Update(ProjectStatus projectStatus);
    void Delete(ProjectStatus projectStatus);
    Task<ProjectStatus?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProjectStatus>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string projectStatusName);
}