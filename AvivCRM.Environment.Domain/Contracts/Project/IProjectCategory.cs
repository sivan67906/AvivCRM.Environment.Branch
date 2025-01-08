#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Project;
public interface IProjectCategory
{
    void Add(ProjectCategory projectCategory);
    void Update(ProjectCategory projectCategory);
    void Delete(ProjectCategory projectCategory);
    Task<ProjectCategory?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProjectCategory>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string projectCategoryName);
}