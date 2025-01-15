#region

using AvivCRM.Environment.Domain.Entities.Recruit;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Recruit;
public interface IJobApplicationPosition
{
    void Add(JobApplicationPosition jobApplicationPosition);
    void Update(JobApplicationPosition jobApplicationPosition);
    void Delete(JobApplicationPosition jobApplicationPosition);
    Task<JobApplicationPosition?> GetByIdAsync(Guid id);
    Task<IEnumerable<JobApplicationPosition>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string jobApplicationPositionName);
}