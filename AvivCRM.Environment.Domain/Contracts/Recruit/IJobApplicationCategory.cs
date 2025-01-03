using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface IJobApplicationCategory
{
    void Add(JobApplicationCategory jobApplicationCategory);
    void Update(JobApplicationCategory jobApplicationCategory);
    void Delete(JobApplicationCategory jobApplicationCategory);
    Task<JobApplicationCategory?> GetByIdAsync(Guid id);
    Task<IEnumerable<JobApplicationCategory>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string jobApplicationCategoryName);
}









