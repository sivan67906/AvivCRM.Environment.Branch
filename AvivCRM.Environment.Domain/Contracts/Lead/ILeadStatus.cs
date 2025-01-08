#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Lead;
public interface ILeadStatus
{
    void Add(LeadStatus leadStatus);
    void Update(LeadStatus leadStatus);
    void Delete(LeadStatus leadStatus);
    Task<LeadStatus?> GetByIdAsync(Guid id);
    Task<IEnumerable<LeadStatus>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string leadStatus);
}